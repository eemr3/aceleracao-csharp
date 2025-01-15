using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Notification.Service.Utils;

public static class LogService
{
  public static void ConfigureLogger()
  {
    Log.Logger = new LoggerConfiguration()
                                   .WriteTo.Console()
                                   .WriteTo.File(new JsonFormatter(),
                                                 "../Logs/notification.service.info.log.json",
                                                 restrictedToMinimumLevel: LogEventLevel.Information,
                                                 rollingInterval: RollingInterval.Minute)
                                   .MinimumLevel.Debug()
                                   .CreateLogger();
  }
}