using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CursoASP.NET.Models
{
    public enum ResultadoOperacion
    {
        Aprobado = 1,
        Rechazado = 2,
        Pendiente = 7,
        [Description("Pendiente Aprobación")]//Permite reemplazar este texto por el valor para incluir espacios en blanco
        PendienteAprobacion = 9
    }
}