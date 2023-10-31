using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intento4.Modelo
{
    public class Estudiante
    {
        //id usuario (PK) , codigo, nombre

        public int ID_usuario { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}