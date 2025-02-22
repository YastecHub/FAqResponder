namespace FAqResponder.Repository
{
    public class TelexRepository : ITelex
    {
        private readonly IConfiguration _config;

        public TelexRepository(IConfiguration config)
        {
            _config = config;
        }

        public TelexConfig GetTelexConfiguration()
        {
            try
            {
                // Map the "TelexIntegration" section to a single TelexConfig object
                var telexConfig = _config.GetSection("TelexIntegration").Get<TelexConfig>();
                if (telexConfig == null)
                {
                    Console.WriteLine("TelexConfig is null.");
                }
                else
                {
                    // Log the deserialized object for debugging
                    Console.WriteLine($"Settings count: {telexConfig.data?.settings?.Count}");
                    Console.WriteLine($"Data: {System.Text.Json.JsonSerializer.Serialize(telexConfig.data)}");
                }
                return telexConfig ?? new TelexConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new TelexConfig();
            }
        }
    }
}