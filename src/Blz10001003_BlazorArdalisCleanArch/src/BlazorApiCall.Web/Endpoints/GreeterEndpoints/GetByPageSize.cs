using Ardalis.ApiEndpoints;
using BlazorApiCall.Contract;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlazorApiCall.Web.Endpoints.GreeterEndpoints;

public class GetByPageSize : EndpointBaseAsync
    .WithRequest<GetAzureDnsByPageSizeRequest>
    .WithActionResult<GetAzureDnsByPageSizeResponse>
{
  //private readonly IRepository<Project> _repository;
//  private readonly IAzureDnsService _azureDnsService;
  //private readonly IHostEnvironment _environment;

  public GetByPageSize(
    // IRepository<Project> repository
    // , IAzureDnsService azureDnsService, 
    //, IHostEnvironment environment
    )
  {
    //_repository = repository;
    // _azureDnsService = azureDnsService;
    //_environment = environment;
  }

  [HttpGet(GetAzureDnsByPageSizeRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets Azure Dns entries",
      Description = "Gets Azure Dns Entries",
      OperationId = "AzureDns.GetByPageSize",
      Tags = new[] { "AzureDnsEndpoints" })
  ]
  public override async Task<ActionResult<GetAzureDnsByPageSizeResponse>> 
    HandleAsync([FromRoute] GetAzureDnsByPageSizeRequest request,
      CancellationToken cancellationToken)
  {
    //var azureCredentials = _azureDnsService.GetCredentialsFromFile(_environment.ContentRootPath + "\\wwwroot" + "\\my.azureauth");

    //var dnsClient = await _azureDnsService.LogIntoServicePrincipalAccount(azureCredentials.TenantId, azureCredentials.ClientId,
    //  azureCredentials.DefaultSubscriptionId);

    //IPage<RecordSet> recoreSets = await _azureDnsService.ListAllByDnsZoneAsync(dnsClient, request.PageSize);

    //List<RecordSetDTO> RecordSets = recoreSets.Select(record => new RecordSetDTO
    //{
    //  Id = record.Id,
    //  Name = record.Name,
    //  Type = record.Type,
    //  Etag = record.Etag
    //}).ToList();

    //var reponse = new GetAzureDnsByPageSizeResponse() { Records = RecordSets };

    //return Ok(reponse);
    return Ok("Hare Krishna");
  }
}
