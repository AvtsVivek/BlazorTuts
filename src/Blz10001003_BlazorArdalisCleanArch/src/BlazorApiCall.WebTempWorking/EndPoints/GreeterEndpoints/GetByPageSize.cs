using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using BlazorApiCall.Contract;
using BlazorApiCall.Web.Endpoints.GreeterEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlazorApiCall.WebTempWorking.Endpoints.GreeterEndpoints;

public class GetByPageSize : EndpointBaseAsync
    .WithRequest<GetAzureDnsByPageSizeRequest>
    .WithActionResult<GetAzureDnsByPageSizeResponse>
{

  public GetByPageSize()
  {
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
    return Ok("Hare Krishna");
  }
}
