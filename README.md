Installation
---
+ Project is built with visual studio 2017
+ Open .sln file to view source code

Setup
---
Update Web.config file to corresponding AWS credentials
```
<configuration>
     <appSettings>
          <add key="AWSProfileName" value="NAME OF USER ACCOUNT"/>
          <add key="AWSAccessKey" value="PUBLIC KEY"/>
          <add key="AWSSecretKey" value="PRIVATE KEY"/>
          <add key="AWSRegion" value="REGION" />
     </appSettings>
<configuration>
```
+ On line 42 of UploadController.cs change to local folder where MP3 files are stored. Currently the directory is hard coded. This is a feature.
```
string rootFolder = @"C:\Users\Ryan\Desktop\mp3s\";
```
```
string rootFolder = @"<FILE DIRECTORY PATH>";
```

Running
---
Run using IIS Express in Visual Studio
