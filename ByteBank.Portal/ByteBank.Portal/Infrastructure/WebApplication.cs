using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infrastructure
{
    public class WebApplication
    {
        private readonly string[] _prefixes;
        public WebApplication(string [] prefixes)
        {
            if(prefixes == null)            
                throw new ArgumentNullException(nameof(prefixes));         
            _prefixes = prefixes;
        }
        public void Iniciar()
        {
            while (true)
            {
                requestManipulator();
            }
        }
        private void requestManipulator ()
        {
            var httpListener = new HttpListener();

            foreach (var prefixe in _prefixes)
                httpListener.Prefixes.Add(prefixe);

            httpListener.Start();

            var context = httpListener.GetContext();
            var request = context.Request;
            var response = context.Response;

            var path = request.Url.AbsolutePath;
            if (path == "/Assets/css/styles.css")
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ByteBank.Portal.Assets.css.styles.css";
                var resourceStream = assembly.GetManifestResourceStream(resourceName);
                var bytesResource = new byte[resourceStream.Length];
                resourceStream.Read(bytesResource, 0, bytesResource.Length);

                response.ContentType = "text/css; charset=utf-8";
                response.StatusCode = 200;
                response.ContentLength64 = resourceStream.Length;
                response.OutputStream.Write(bytesResource, 0, bytesResource.Length);
                response.OutputStream.Close();

            }
            else if (path == "/Assets/js/main.js")
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ByteBank.Portal.Assets.js.main.js";
                var resourceStream = assembly.GetManifestResourceStream(resourceName);
                var bytesResource = new byte[resourceStream.Length];
                resourceStream.Read(bytesResource, 0, bytesResource.Length);

                response.ContentType = "text/js; charset=utf-8";
                response.StatusCode = 200;
                response.ContentLength64 = resourceStream.Length;
                response.OutputStream.Write(bytesResource, 0, bytesResource.Length);
                response.OutputStream.Close();
            }

            httpListener.Stop();
        }
    }
}
