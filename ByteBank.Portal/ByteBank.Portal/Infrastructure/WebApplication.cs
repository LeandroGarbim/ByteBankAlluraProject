using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var httpListener = new HttpListener();

            foreach(var prefixe in _prefixes)
                httpListener.Prefixes.Add(prefixe);           

            httpListener.Start();

            var context = httpListener.GetContext();
            var request = context.Request;
            var response = context.Response;

            var responseContent = "Hello World";
            var responseContentBytes = Encoding.UTF8.GetBytes(responseContent);
            response.ContentType = "text/html; charset=utf-8";
            response.StatusCode = 200;
            response.ContentLength64 = responseContentBytes.Length;

            response.OutputStream.Write(responseContentBytes, 0, responseContentBytes.Length);

            response.OutputStream.Close();
            httpListener.Stop();


        }
    }
}
