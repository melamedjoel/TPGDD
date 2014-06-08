using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Validator
    {
        public static string SoloNumeros(string textoAValidar, string nombreCampo)
        {
            string strError = "";

            if (strError.Length == 0 && !EsNumero(textoAValidar))
            {
                strError += "El campo " + nombreCampo + " tiene caracteres invalidos\n";
            }
            return strError;
        }

        public static bool EsNumero(object obj)
        {
            try
            {
                int.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string ValidarNulo(string textoAValidar, string nombreCampo)
        {
            if (string.IsNullOrEmpty(textoAValidar))
            {
                return "Tiene que ingresar un valor para el campo " + nombreCampo + "\n";
            }
            return string.Empty;
        }
    }
        
}
