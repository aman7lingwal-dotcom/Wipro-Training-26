using Serilog;

namespace UserManagementApp.Logging
{
    public static class LoggerConfig
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
