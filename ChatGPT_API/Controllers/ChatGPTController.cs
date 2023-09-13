using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Text;

namespace ChatGPT_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData(string input)
        {
            try
            {
                string apiKey = "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";
                string response = "";
                OpenAIAPI openai = new OpenAIAPI(apiKey);
                CompletionRequest completion = new CompletionRequest();
                completion.Prompt = input;
                completion.Model = "text-davinci-003";
                completion.MaxTokens = 4000;
                var output = await openai.Completions.CreateCompletionAsync(completion);
                if (output != null)
                {
                    foreach (var item in output.Completions)
                    {
                        response = item.Text;
                    }
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at Get ChatGPT Method" + ex.Message);
                return BadRequest("Error");            }
            
        }

        [HttpGet]
        [Route("/GetGpt")]
        public async Task<IActionResult> Get(string query)
        {
            try
            {
                string apiKey = "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";
                string apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                string inputMessage = query;
                var requestData = new
                {
                    prompt = inputMessage,
                    max_tokens = 50, // You can adjust this as needed
                };
                var requestContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiUrl, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return Ok(responseBody);
                 
                }
                else
                {
                    return BadRequest($"HTTP request failed with status code: {response.StatusCode}");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        //string apikey = "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";
        //    string response = "";
        //    OpenAIAPI openAIAPI = new OpenAIAPI(apikey);
        //    CompletionRequest completion = new CompletionRequest();
        //    completion.Prompt = input;
        //    completion.Model = "text-davinci-003";
        //    completion.MaxTokens = 4000;
        //    var output=await openAIAPI.Completions.CreateCompletionAsync(completion);

        //    if(output != null)
        //    {
        //        foreach (var item in output.Completions)
        //        {
        //            response=item.Text;
        //        }
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest("Not Found");
        //    }
        //}
       
    }
}
