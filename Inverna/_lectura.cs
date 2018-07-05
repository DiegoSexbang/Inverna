using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inverna
{
    public partial class Lectura
    {
        private BD db = new BD();

        public List<Lectura> lect()
        {
           

           List<Lectura> lec =  db.Lectura.Include("TipoLectura").ToList();

            return lec;
            

           
        }
    }
}