using IOTWebAPI.Entities;

namespace IOTWebAPI.DTOs
{
    public class CreateConfigurationDto
    {
        public int ConfigurationID { get; set; }
        public int GatewayID { get; set; }
        public string Details { get; set; }
    }
}
