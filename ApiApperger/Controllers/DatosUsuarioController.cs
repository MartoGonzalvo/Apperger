using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiApperger.Controllers
{
    public class DatosUsuarioController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();

        [HttpGet]
        [ActionName("XAMARIN_DATOS")]

        public List<TratamientoModel> Datos(string username)
        {
            //var user = DB.usuarios.Where(x => x.sUsuario == username && x.sContraseña == password).FirstOrDefault();

            var query = DB.usuarios.Join(DB.Tratamientoes, x => x.nIdUsuario, y => y.nIdPaciente, (x, y) => new { x.nIdUsuario, x.sNombre, x.sUsuario, y.bSelfie, y.bImagen, y.bVideo, y.nIdTratamiento }).Where(usrName => usrName.sUsuario == username);
            List<TratamientoModel> listaTratamiento = new List<TratamientoModel>();
            TratamientoModel tratamientoUsuario = new TratamientoModel();
            foreach (var lista in query)
            {
                tratamientoUsuario.idTratamiento = lista.nIdTratamiento;
                tratamientoUsuario.idUsuario = lista.nIdUsuario;
                tratamientoUsuario.selfie = Convert.ToBoolean(lista.bSelfie);
                tratamientoUsuario.video = Convert.ToBoolean(lista.bVideo);
                tratamientoUsuario.imagen = Convert.ToBoolean(lista.bImagen);
                tratamientoUsuario.nombre = lista.sNombre;
                listaTratamiento.Add(tratamientoUsuario);
            }

            return listaTratamiento;
        }
    }
}
