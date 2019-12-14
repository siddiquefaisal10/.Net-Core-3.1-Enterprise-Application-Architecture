using TwinCityCoders.DBCore.Context.EFContext;

namespace TwinCityCoders.DBCore.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}
