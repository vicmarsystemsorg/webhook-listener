# webhook-listener
Main responsibilities associated with this project code:
1.- Test the API Rest integration / connectivity (wich headers are required, authorization header, etc)
2.- Listen for webhook deliveries
3.- Create repositories and add protection rules to it.
4.- Create issues for an specific repository

## How to install and run the project.
The required steps are listed below:
1. To expose the local environment to the internet, download ngrok. https://ngrok.com/download
2. After installing ngrok, you can expose your localhost by running ./ngrok http 7274 on the command line. 7274 s the port number on which our server will listen for messages. You should see a line that looks something like this: $ Forwarding    http://7e9ea9dc.ngrok.io -> 127.0.0.1:7274
3. Make a note of the *.ngrok.io URL. This must be used to setup the webhook
4. Clone the repo into your local environment.
5. Open the solution name "Webhook.Listener.sln" with a Visual Studio 2022 software (it could be the community edition)
6. Create a Personal Access Token for a user within the organization to use the Rest API. The details on how to create a Personal Access Token are found here: https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token
7. Open the file "HttpClientFabric.cs" in "Webhook.Listener.API" + "GitHub.ApiService.Module" + "Fabric". In line 13, you must write down the personal access token as a second parameter to the AuthenticationHeaderValue object, so the app can perform actions to the Github organization.
8. Open the file "WebHookService.cs" in "Webhook.Listener.API" + "GitHub.ApiService.Module" + "Services". In Line 28 (url = ""), provide the the *.ngrok.io URL from step 3. This is required to create a webhook properly.
9. Build the solution to download the required nuget packages.
10. Press F5 to start the web service.

## How to use the solution.
1.- When you run the solution, you must see a Swagger page like this one
![Swagger Home](https://github.com/vicmarsystemsorg/webhook-listener/blob/main/Reference_Images/Swagger_Home.PNG)