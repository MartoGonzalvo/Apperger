using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppergerWeb.Models;


namespace AppergerWeb.Controllers
{
    public class ImagenAzureController : Controller
    {
        List<Models.imagenes> imglist = new List<Models.imagenes>();

        // GET: ImagenAzure
        public ActionResult Cargarlistar(string nombre)
        {
            CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["appergerstorage_AzureStorageConnectionString"].ConnectionString);
            CloudBlobClient blobclient = StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobclient.GetContainerReference("apperger");
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference(File.FileName);
            if (nombre != null) {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(nombre);
                blockBlob.Delete();
                foreach (IListBlobItem item in container.ListBlobs(null, true))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        imagenes img = new imagenes(blob.Name, blob.Uri.AbsoluteUri);
                        this.imglist.Add(img);
                    }

                }
                return View(imglist);
            }
            else
                foreach (IListBlobItem item in container.ListBlobs(null, true))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        imagenes img = new imagenes(blob.Name, blob.Uri.AbsoluteUri);
                        this.imglist.Add(img);
                    }

                }
            return View(imglist);
        }

           
        
        [HttpPost]
        public ActionResult Cargarlistar2(string nombre)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength>0)
            {
                CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["appergerstorage_AzureStorageConnectionString"].ConnectionString);
                CloudBlobClient blobclient = StorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobclient.GetContainerReference("apperger");
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);
                blockBlob.Properties.ContentType="image/jpeg";

                blockBlob.UploadFromStream(file.InputStream);

         



            }
            return RedirectToAction("Cargarlistar");

        }


    }
}