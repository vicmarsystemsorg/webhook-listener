using System.Text;
using System.Text.Json;
using Webhook.Listener.API.DTOS.Issues;
using Webhook.Listener.API.DTOS.Repository;
using Webhook.Listener.API.Github.ApiService.Module.Fabric;

namespace Webhook.Listener.API.Github.ApiService.Module.Services
{
    public class IssuesService
    {
        public void CreateIssue(RepositoryDTO repositoryDTO)
        {
            var httpClient = HttpClientFabric.GetHttpClient();

            var createIssueDTO = GetCreteIssueDTO();

            var json = JsonSerializer.Serialize(createIssueDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var uriEndpoint = $"{repositoryDTO.repository.url}/issues";

            HttpResponseMessage response = httpClient.PostAsync($"{uriEndpoint}", data).Result;
            HttpContent content = response.Content;
        }

        private CreateIssueDTO GetCreteIssueDTO()
        {
            var createIssueDTO = new CreateIssueDTO
            {
                accept = "application/vnd.github.v3+json",
                title = "Protection rules added successfuly",
                body = "Protection rules addedd sucessfuly to this repository @vicmarsystems",
                assignees = new string[1] { "vicmarsystems"}
            };

            return createIssueDTO;
        }
    }
}
