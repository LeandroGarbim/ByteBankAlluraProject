using ByteBank.Portal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prefixes = new string[] { "http://localhost:5341/" };
            var webApplication = new WebApplication(prefixes);
            webApplication.Iniciar();

        }
    }
}
