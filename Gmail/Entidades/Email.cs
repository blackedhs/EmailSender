using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Entidades
{
    public class Email
    {
        public string Nombre { get; set; }
        public string DireccionEmail { get; set; }
        public string Description { get; set; }

        public Email()
        {
        }
        public Email(string nombre,string direccion,string descripcion)
        {
            Nombre = nombre;
            if (IsEmail(direccion))
                DireccionEmail = direccion;
            else
                DireccionEmail = null;
            Description = descripcion;
        }
        public bool Equals(Email e2)
        {
            return DireccionEmail == e2.DireccionEmail;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}   ||   {1}", this.DireccionEmail, this.Nombre);
            return sb.ToString();
        }
        public static bool IsEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}