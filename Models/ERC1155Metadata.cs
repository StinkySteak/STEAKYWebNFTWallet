using System;

public class NFTMetadata
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public Dictionary<string,object> Properties { get; set; } = new Dictionary<string,object>();
}
