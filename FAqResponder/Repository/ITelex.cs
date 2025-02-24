using FAqResponder.Model;

namespace FAqResponder.Repository
{
    public interface ITelex
    {
        TelexConfig GetTelexConfiguration();

        string ProcessMessage(FaqRequest request);
    }
}
