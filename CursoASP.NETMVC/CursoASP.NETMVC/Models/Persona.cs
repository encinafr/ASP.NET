﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASP.NETMVC.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Edad { get; set; }
        public virtual List<Dirección> Direcciones { get; set; }
    }
}