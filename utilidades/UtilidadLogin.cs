using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilidades
{
    public static class UtilidadLogin
    {
        public static bool sesionActiva(object usuarioActivo)
        {
            return (Usuario)usuarioActivo != null ? true : false;            
        }

        public static bool esAdmin(object usuarioLogeado)
        {
            return (Usuario)usuarioLogeado != null ? ((Usuario)usuarioLogeado).Admin : false;
        }
    }
}
