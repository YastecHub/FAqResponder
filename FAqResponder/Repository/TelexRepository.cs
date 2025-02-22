using FAqResponder.Model;

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
                var telexConfig = _config.GetSection("TelexIntegration").Get<TelexConfig>();
                if (telexConfig == null)
                {
                    Console.WriteLine("TelexConfig is null.");
                }
                else
                {
                    Console.WriteLine($"Settings count: {telexConfig.settings?.Count}");
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
