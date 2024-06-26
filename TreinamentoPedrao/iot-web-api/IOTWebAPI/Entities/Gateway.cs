namespace IOTWebAPI.Entities;

public class Gateway
{
    public int GatewayID { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; }
    public DateTime LastCommunication { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Configuration Configuration { get; set; } //Representa a rela��o 1 pra 1, a classe Gateway tem acesso �s infos de Configuration
}