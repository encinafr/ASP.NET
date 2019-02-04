using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASP.NETMVC.Models
{
    public class Dirección
    {
        public int CodigoDirección { get; set; }
        public string Calle { get; set; }
        public Persona Persona { get; set; }
    }
}