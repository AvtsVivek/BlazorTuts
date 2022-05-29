namespace BlazorApiCall.Contract;

public class GetAzureDnsByPageSizeResponse
{
  public List<RecordSetDTO> Records { get; set; } = new();
}

public class RecordSetDTO
{
  public string Id { get; set; } = string.Empty;

  //
  // Summary:
  //     Gets the name of the record set.
  public string Name { get; set; } = string.Empty;

  //
  // Summary:
  //     Gets the type of the record set.
  public string Type { get; set; } = string.Empty;

  //
  // Summary:
  //     Gets or sets the etag of the record set.
  public string Etag { get; set; } = string.Empty;
}
