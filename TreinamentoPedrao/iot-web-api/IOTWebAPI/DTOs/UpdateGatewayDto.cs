namespace IOTWebAPI.DTOs;

public class UpdateGatewayDto
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; }
}