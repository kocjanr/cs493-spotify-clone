using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace spotify_clone.Models
{
     public class AWS
     {
          public void CreateS3Bucket(String name)
          {
               NameValueCollection appConfig = ConfigurationManager.AppSettings;
               
               AmazonS3Client client = new AmazonS3Client(
                    appConfig["AWSAccessKey"],
                    appConfig["AWSSecretKey"],
                    Amazon.RegionEndpoint.USWest2
               );

               PutBucketRequest request = new PutBucketRequest();
               request.BucketName = name;
               client.PutBucket(request);

               ListBucketsResponse response = client.ListBuckets();
          }

          public void UploadToS3(String bucket, String fileName, String filePath)
          {
               NameValueCollection appConfig = ConfigurationManager.AppSettings;

               AmazonS3Client client = new AmazonS3Client(
                    appConfig["AWSAccessKey"],
                    appConfig["AWSSecretKey"],
                    Amazon.RegionEndpoint.USWest2
               );

               PutObjectRequest putRequest = new PutObjectRequest
               {
                    BucketName = bucket,
                    Key = fileName,
                    FilePath = filePath
               };

               PutObjectResponse response = client.PutObject(putRequest);
          }

          public List<String> GetSongsFromBucket()
          {
               NameValueCollection appConfig = ConfigurationManager.AppSettings;

               List<String> songLinks = new List<string>();
               string bucketName = "toast-hw6-files";

               AmazonS3Client client = new AmazonS3Client(
                    appConfig["AWSAccessKey"],
                    appConfig["AWSSecretKey"],
                    RegionEndpoint.USWest2
               );

               ListObjectsRequest request = new ListObjectsRequest();
               request.BucketName = bucketName;
               ListObjectsResponse response = client.ListObjects(request);
               foreach (S3Object o in response.S3Objects)
               {
                    Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);
                    songLinks.Add(o.Key);
               }

               return songLinks;
          }
     }
}