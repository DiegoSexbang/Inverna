//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inverna
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lectura
    {
        public int idlectura { get; set; }
        public double valor { get; set; }
        public System.DateTime hora { get; set; }
        public int tipolectura_idtipolectura { get; set; }
    
        public virtual TipoLectura TipoLectura { get; set; }
    }
}
