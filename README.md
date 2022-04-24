# webhook-listener
Main responsibilities associated with this project code:
1. Test the API Rest integration / connectivity (wich headers are required, authorization header, etc)
2. Listen for webhook deliveries
3. Create repositories and add protection rules to it.
4. Create issues for an specific repository

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
1. When you run the solution, you must see a Swagger page like this one
![Swagger Home](https://github.com/vicmarsystemsorg/webhook-listener/blob/main/Reference_Images/Swagger_Home.PNG)
2. First, you must create a webhook associated to the repository event, so when a new repository is created, the webhook will delivery that information into the "webhook-listener" solution.
To do this, execute the "CreateWebHookCreateRepoEvent". Click on the "api/GitHubApiInteraction/CreateWebHookCreateRepoEvent" on Swagger; click on "Try it out" button. Then, as this method does not need any parameter, just click the "Execute" button. See the following image
![Execute CreateWebHookCreateRepoEvent method](https://github.com/vicmarsystemsorg/webhook-listener/blob/main/Reference_Images/CreateWebHookCreateRepoEvent_Execute.PNG)
3. Next, you can create a repository to see the automation creation of the protection rules and related issue. Keep in mind that this will create a default readme file in the repository to create the default branch.
To create the repository, execute the "CreateRepository" method. Click on the "api/GitHubApiInteraction/CreateRepository" on Swagger; click on "Try it out" button. Enter a repository name, then click on the "Execute" button. As in the following image
![Execute CreateRepository method](https://github.com/vicmarsystemsorg/webhook-listener/blob/main/Reference_Images/CreateRepository_Execute.PNG)
4. Now, to confirm the automatic creation of the protection rule and related issue:
5. **Protection Rules**. In the Github web site, go to the home page of the repository you just created. Then go to "Settings" and then Branches. You must see a new protection rule created under the "Branch protection rules" section. See the following image
![Branch Protection Rules](https://github.com/vicmarsystemsorg/webhook-listener/blob/main/Reference_Images/Branch_Protection_Rules.PNG)
6. **Issues**. In the Github web site, in the home page of the repository created, go to "Issues". You must see the created issue. As in the following image:
![Issues](https://github.com/vicmarsystemsorg/webhook-listener/blob/main/Reference_Images/Issues.png)