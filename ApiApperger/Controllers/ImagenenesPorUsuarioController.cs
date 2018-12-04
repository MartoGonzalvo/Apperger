using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiApperger.Controllers
{
    public class ImagenesPorUsuarioController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();

        [HttpGet]
        [ActionName("XAMARIN_ListarImagenes")]

        
        public List<TratamientoModel> Xamarin_ListarImagenes(int idUsuario)
        {
            List<TratamientoModel> listado = new List<TratamientoModel>();
            TratamientoModel tratamientoUsuario = new TratamientoModel();
            

            var listaDeImagenes = (from tratamiento in DB.Tratamientoes
                                   join imagenTratamiento in DB.ImagenTratamientoes on tratamiento.nIdTratamiento equals imagenTratamiento.nIdTratamiento
                                   join imagen in DB.Imagens on imagenTratamiento.nIdImagen equals imagen.nIdImagen
                                   where tratamiento.nIdPaciente == idUsuario
                                   select new TratamientoModel { sImagen = imagen.sImagen, idEmocion = imagen.nIdEmocion.Value, nidImagen = imagenTratamiento.nIdImagen.Value }).ToList();


            /*foreach (var lista in listaDeImagenes)
            {
                tratamientoUsuario.sImagen = lista.sImagen;
                tratamientoUsuario.idEmocion = lista.idEmocion;*/
            //listado.Add(listaDeImagenes);
            //}

            return listaDeImagenes;
        }
    }
}