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
            {
                throw new ArgumentNullException(nameof(prefixes));
                _prefixes = prefixes;
            }
        }
        public void Iniciar()
        {
            var httpListener = new HttpListener();

            foreach(prefixe in _prefixes)
                httpListener.Prefixes.Add(prefixe);           

            httpListener.Start();

            var context = httpListener.GetContext();
            var request = context.Request;
            var response = context.Response;


        }
    }
}
