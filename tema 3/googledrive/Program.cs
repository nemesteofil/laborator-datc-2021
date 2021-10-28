using System;

namespace googledrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        ststic void Initialize()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,  
                               DriveService.Scope.DriveFile,};  

              var clientId = "592955076853-e9ruom1ob5tllqrk4sh9cjquiktcl78b.apps.googleusercontent.com";      // From https://console.developers.google.com  
              var clientSecret = "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";          // From https://console.developers.google.com  
                                           // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
              var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets  
              {  
                  ClientId = clientId,  
                  ClientSecret = clientSecret  
              },scopes,  
              Environment.UserName,
              CancellationToken.None,
              new FileDataStore("MyAppsToken")
              ).Result;  
              //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   
  
              _service = new DriveService(new BaseClientService.Initializer()  
              {  
                  HttpClientInitializer = credential,  
                  
  
              });
              _token = credential.Token.AccessToken;
              Console.Write("Token "+credential.Token.AccessToken);
        }
    }
}
