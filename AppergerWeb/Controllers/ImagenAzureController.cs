using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppergerWeb.Controllers
{
    public class ImagenAzureController : Controller
    {
      

        // GET: ImagenAzure
        public ActionResult Cargarlistar()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Cargarlistar2(string nombre)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength>0)
            {
                CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["appergerstorage_AzureStorageConnectionString"].ConnectionString);
                CloudBlobClient blobclient = StorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobclient.GetContainerReference("imagenes");
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                blockBlob.UploadFromStream(file.InputStream);

         



            }
            return View();

        }


    }
}