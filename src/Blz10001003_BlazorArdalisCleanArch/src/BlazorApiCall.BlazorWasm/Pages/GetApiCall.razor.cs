﻿using Ardalis.HttpClientTestExtensions;
using BlazorApiCall.Contract;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Net.Http.Json;
using static BlazorApiCall.BlazorWasm.Pages.FetchData;

namespace BlazorApiCall.BlazorWasm.Pages;
public partial class GetApiCall
{

  [Inject]
  private HttpClient Http { get; set; } = new HttpClient();

 // [Inject]
 // private IAzureDnsService AzureDnsService { get; set; } = default!;

  //[Inject]
  //private IHostEnvironment Environment { get; set; } = default!;

  private WeatherForecast[]? forecasts;
  private List<RecordSetDTO> recordSets;

  //protected override async Task OnInitializedAsync()
  //{
  //  //forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
  //}

  private async Task IncrementCount()
  {
    // forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("http://localhost:57678/AzureDns/3");
    try
    {
      var temp = "http://localhost:57678/AzureDns/3"; // http://localhost:57678/swagger/index.html
      //var temp = "http://localhost:8830/infoendpoint";
      //var re = await Http.GetAsync(temp);

      var requestMessage = new HttpRequestMessage()
      {
        Method = new HttpMethod("GET"),
        RequestUri = new Uri(temp),
        //Content = JsonContent.Create(new Player
        //{
        //  PlayerName = $"{player.PlayerName}"
        //})
      };
      var response = await Http.SendAsync(requestMessage);
      var finalMessage = await response.Content.ReadAsStringAsync();
      // var result = await Http.GetAndDeserialize<GetAzureDnsByPageSizeResponse>(temp);
      // var response = await Http.GetFromJsonAsync<GetAzureDnsByPageSizeResponse>("http://localhost:57678/AzureDns/3");
      // recordSets = response!.Records;
    }
    catch (Exception exce)
    {
      var message = exce.Message;
      var innerException = exce.InnerException!.Message;
      Debugger.Break();
      throw;
    }
    // GetAzureDnsByPageSizeResponse
  }

  private async Task PostRequest()
  {
    // https://localhost:53049/api/HandOfCards
    //           new Uri("https://localhost:44348/api/HandOfCards/"
    Player player = new Player() { PlayerName="Vivek" };
    try
    {
      var requestMessage = new HttpRequestMessage()
      {
        Method = new HttpMethod("POST"),
        RequestUri =
          new Uri("https://localhost:53049/api/HandOfCards/"
             + player.PlayerName),
        Content =
          JsonContent.Create(new Player
          {
            PlayerName = $"{player.PlayerName}"
          })
      };
      var response = await Http.SendAsync(requestMessage);
      var playerName = $"{player.PlayerName}, here are your cards.";
      Stream stream = await response.Content.ReadAsStreamAsync();
      StreamReader reader = new StreamReader(stream);
      //var results = JsonConvert.DeserializeObject<dynamic>(reader.ReadLine());
      reader.Close();
      //foreach (var card in results)
      //{
      //  cards.Add((string)card.imageLink);
      //}
    }
    catch (Exception ex)
    {
      // responseBody = ex.Message + " - " + ex.StackTrace;
    }
  }
}

public class Player
{
  public string PlayerName { get; set; } = String.Empty;
}
