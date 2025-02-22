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
                if (_config.GetSection("TelexIntegration").Key == null)
                    return new TelexConfig();

                return _config.GetSection("TelexIntegration").Get<TelexConfig>()!;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new TelexConfig();
            }
        }

    }
}
