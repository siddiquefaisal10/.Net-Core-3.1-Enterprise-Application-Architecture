using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using TwinCityCoders.Models.Configuration;
using TwinCityCoders.Sockets.Models;

namespace TwinCityCoders.Sockets.TestMessage
{
    public class TestMessageCounter : ITestMessageCounter
    {
        private const string TableName = "WeatherForecasts";
        private SqlTableDependency<WeatherForecast> _notifier;
        private readonly IOptions<ConnectionSettings> _connectionOptions;
        private IHubContext<MainHub> _hub;

        public TestMessageCounter(IHubContext<MainHub> hub, IOptions<ConnectionSettings> connectionOptions)
        {
            _hub = hub;
            _connectionOptions = connectionOptions;

            _notifier = new SqlTableDependency<WeatherForecast>(_connectionOptions.Value.DefaultConnection, TableName);
            _notifier.OnChanged += this.TableDependency_Changed;
            _notifier.Start();
        }

        private void TableDependency_Changed(object sender, RecordChangedEventArgs<WeatherForecast> e)
        {
            var data = e.Entity;
            _hub.Clients.All.SendAsync("transferchartdata", data);
        }


        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }

}
