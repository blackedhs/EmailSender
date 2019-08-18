using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class XML
    {
        public bool Guardar(List<Email> emails, string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Email>));
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                {
                    ser.Serialize(writer, emails);
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Email> Abrir(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Email>));
            List<Email> emails = new List<Email>();
            try
            {
                using (XmlTextReader reader = new XmlTextReader(path))
                {
                    emails = (List<Email>)ser.Deserialize(reader);
                    return emails;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
