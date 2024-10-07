using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool SessionVoucherActivo(object V)
        {
            if (V != null)
                return true;

            return false;
        }
    }
}
