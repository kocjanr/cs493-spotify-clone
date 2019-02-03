﻿using System;
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
               SongsViewController vc = new SongsViewController();

               AWS aws = new AWS();
               var songs = aws.GetSongsFromBucket();

               vc.Songs = songs;
               return View(vc);
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
          public ActionResult UploadFile(String fileupload)
          {
               string rootFolder = @"C:\Users\Ryan\Desktop\mp3s\";

               string filePath = rootFolder + fileupload;

               AWS aws = new AWS();
               string bucket = "toast-hw6-files";
             

               aws.UploadToS3(bucket, fileupload, filePath);

               return RedirectToAction("Index", "Upload");
          }
     }
}