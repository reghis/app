using System;
using System.Collections.Generic;
using System.Text;

namespace CEntidades
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string FonoPersonal { get; set; }
        public string FonoDom { get; set; }
        public byte[] FileAdjunto1 { get; set; }

    }
}
