using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Entities
{    
    public class Usuario
    {
        public string idUsuario { get; set; }
        public int idRol { get; set; }
        public string descripcion { get; set; }
        public string clave { get; set; }
        public string[] guards { get; set; }
    }
}
