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

        /*public List<String> Xamarin_ListarImagenes(int idUsuario)
        {
            List<String> listaDeImagenes = new List<String>();

            listaDeImagenes = (from usuario in DB.usuarios
                               join tratamiento in DB.Tratamientoes on usuario.nIdUsuario equals tratamiento.nIdPaciente
                               join ImagenTratamiento in DB.ImagenTratamientoes on tratamiento.nIdTratamiento equals ImagenTratamiento.nIdTratamiento
                               join imagen in DB.Imagens on ImagenTratamiento.nIdImagen equals imagen.nIdImagen
                               where usuario.nIdUsuario == idUsuario
                               select imagen.sImagen).ToList();

            return listaDeImagenes;
        }*/

        public List<TratamientoModel> Xamarin_ListarImagenes(int idUsuario)
        {
            List<TratamientoModel> listado = new List<TratamientoModel>();
            TratamientoModel tratamientoUsuario = new TratamientoModel();
            //var query = DB.usuarios.Join(DB.Tratamientoes, x => x.nIdUsuario, y => y.nIdPaciente, (x, y) => new { x.nIdUsuario, x.sUsuario, y.bSelfie, y.bImagen, y.bVideo, }).Where(usrName => usrName.sUsuario == username);
            /*var listaDeImagenes = (from usuario in DB.usuarios
                               join tratamiento in DB.Tratamientoes on usuario.nIdUsuario equals tratamiento.nIdPaciente
                               join ImagenTratamiento in DB.ImagenTratamientoes on tratamiento.nIdTratamiento equals ImagenTratamiento.nIdTratamiento
                               join imagen in DB.Imagens on ImagenTratamiento.nIdImagen equals imagen.nIdImagen
                               join emocion in DB.Emocions on imagen.nIdEmocion equals emocion.nIdEmocion
                               where tratamiento.nIdPaciente == idUsuario
                               select new TratamientoModel{ sImagen = imagen.sImgen, idEmocion = imagen.nIdEmocion.Value });*/

            var listaDeImagenes = (from tratamiento in DB.Tratamientoes
                        join imagenTratamiento in DB.ImagenTratamientoes on tratamiento.nIdTratamiento equals imagenTratamiento.nIdTratamiento
                        join imagen in DB.Imagens on imagenTratamiento.nIdImagen equals imagen.nIdImagen
                        where tratamiento.nIdPaciente == idUsuario
                        select new TratamientoModel { sImagen = imagen.sImagen, idEmocion = imagen.nIdEmocion.Value }).ToList();
                        

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