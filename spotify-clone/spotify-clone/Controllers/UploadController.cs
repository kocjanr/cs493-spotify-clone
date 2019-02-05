using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using spotify_clone.Models;
using spotify_clone.ViewControllers;


namespace spotify_clone.Controllers
{
     public class UploadController : Controller
     {
          public ActionResult Index()
          {
               return View();
          }

          public ActionResult Upload()
          {
               return View();
          }

          public ActionResult NewBucket()
          {
               AWS aws = new AWS();
                
               aws.CreateS3Bucket("RyanKojan-Cloud-Bucket-Songs");
               return View();
          }


          [HttpPost]
          public ActionResult UploadFile(String fileupload, String artist, String album)
          {
               String bucket = "cs493.ryankojan.files."+ artist;
               String path = bucket + "/"+album;

               AWS aws = new AWS();
               aws.CreateS3Bucket(bucket);

               string rootFolder = @"C:\Users\Ryan\Desktop\mp3s\";

               string filePath = rootFolder + fileupload;

               aws.UploadToS3(path, fileupload, filePath);

               return RedirectToAction("Index", "Upload");
          }
     }
}