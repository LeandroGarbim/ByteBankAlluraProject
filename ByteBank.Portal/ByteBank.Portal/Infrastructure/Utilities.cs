using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infrastructure
{
    public static class Utilities
    {
        public static string ConvertPathToAssemblyName (string path)
        {
            var AssemblyPrefixe = "ByteBank.Portal";
            var FormatedPath = path.Replace("/", ".");
            var AssemblyName = $"{AssemblyPrefixe}{FormatedPath}";

            return AssemblyName;
        }
        public static string GetContentType(string path)
        {
            if (path.EndsWith(".css"))
                return "text/css; charset=utf-8";

            if (path.EndsWith(".js"))
                return "application/js; charset=utf-8";

            if (path.EndsWith(".html"))
                return "text/html; charset=utf-8";

            throw new NotImplementedException("Tipo de Conteúdo não previsto.");
        }
    }
}
