using Ardalis.ApiEndpoints;
using BlazorApiCall.Contract;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlazorApiCall.Web.Endpoints.GreeterEndpoints;

public class GetByPageSize : EndpointBaseAsync
    .WithRequest<GetAzureDnsByPageSizeRequest>
    .WithActionResult<GetAzureDnsByPageSizeResponse>
{
  public GetByPageSize() {}

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
