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

Running
---
Run using IIS Express in Visual Studio
