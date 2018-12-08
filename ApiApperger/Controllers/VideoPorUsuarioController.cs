using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiApperger.Controllers
{
    public class VideoPorUsuarioController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();
        [HttpGet]
        [ActionName("XAMARIN_ListarVideos")]
        public List<TratamientoModel> Xamarin_Listarvideos(int idUsuario)
        {
            List<TratamientoModel> listado = new List<TratamientoModel>();
            TratamientoModel tratamientoUsuario = new TratamientoModel();


            var listaDeVideos = (from tratamiento in DB.Tratamientoes
                                 join videoTratamiento in DB.VideoTratamientoes on tratamiento.nIdTratamiento equals videoTratamiento.nIdTratamiento
                                 join video in DB.Videos on videoTratamiento.nIdVideo equals video.nIdVideo
                                 where tratamiento.nIdPaciente == idUsuario
                                 select new TratamientoModel { sVideo = video.sVideo/*, idEmocion = video.nIdEmocion.Value*/, nidVideo = videoTratamiento.nIdVideo.Value }).ToList();


            /*foreach (var lista in listaDeImagenes)
            {
                tratamientoUsuario.sImagen = lista.sImagen;
                tratamientoUsuario.idEmocion = lista.idEmocion;*/
            //listado.Add(listaDeImagenes);
            //}

            return listaDeVideos;
        }
    }
}