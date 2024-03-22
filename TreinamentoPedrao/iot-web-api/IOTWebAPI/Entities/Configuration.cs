namespace IOTWebAPI.Entities
{
    public class Configuration
    {
        public int ConfigurationID { get; set; }
        public int GatewayID { get; set; }
        public string Details { get; set; }
        public Gateway Gateway { get; set; } //Representa a relação 1 pra 1, a classe Configuration tem acesso às infos de Gateway
    }
}
