using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASP.NET.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EstaEnCArtelera { get; set; }
        public string Genero { get; set; }
    }
}