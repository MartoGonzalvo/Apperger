using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppergerWeb.Models
{
    public class imagenes
    {
        public imagenes(){}
    public imagenes(string nombre, string url){
            this.Nombre = nombre;
            this.Url = url;
        }

        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}