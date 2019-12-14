using TwinCityCoders.Models.Entities.TestTableEntity;

namespace TwinCityCoders.Services.Test
{
    public interface ITestService
    {
        string Login();
        TestTable DbLinq();
        TestTable SpQuery();
    }
}