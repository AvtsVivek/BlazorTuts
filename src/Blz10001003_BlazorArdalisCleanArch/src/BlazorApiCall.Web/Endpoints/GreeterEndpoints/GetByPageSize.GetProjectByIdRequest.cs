
namespace BlazorApiCall.Web.Endpoints.GreeterEndpoints;

public class GetAzureDnsByPageSizeRequest
{
  public const string Route = "/AzureDns/{PageSize:int}";
  public static string BuildRoute(int pageSize) => Route.Replace("{PageSize:int}", pageSize.ToString());

  public int PageSize { get; set; }
}
