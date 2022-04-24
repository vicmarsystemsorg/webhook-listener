# webhook-listener
Main responsibilities associated with this project code:
1.- Test the API Rest integration / connectivity (wich headers are required, authorization header, etc)
2.- Listen for webhook deliveries
3.- Create repositories and add protection rules to it.
4.- Create issues for an specific repository

## How to install and run the project.
The required steps are listed below:
1. Clone the repo into your local environment.
2. Open the solution name "Webhook.Listener.sln" with a Visual Studio 2022 software (it could be the community edition)
3. **Important** You must open the file "HttpClientFabric.cs" in "Webhook.Listener.API" + "GitHub.ApiService.Module" + "Fabric". In line 13, you must write down the personal access token as a second parameter to the AuthenticationHeaderValue object, so the app can perform actions to the Github organization.
4. Build the solution to download the required nuget packages.
5. Press F5 to start the web service.
6. To expose the local environment to the internet, download ngrok. https://ngrok.com/download [ngrok] (https://ngrok.com/download)
7. After installing ngrok, you can expose your localhost by running ./ngrok http 7274 on the command line. 7274 s the port number on which our server will listen for messages. You should see a line that looks something like this: $ Forwarding    http://7e9ea9dc.ngrok.io -> 127.0.0.1:7274
8. Make a note of the *.ngrok.io URL. This must be used to setup the webhook

## How to use the solution.