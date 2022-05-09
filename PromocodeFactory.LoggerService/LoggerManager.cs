using NLog;
using PromocodeFactory.Infrastructure.Interfaces;


namespace PromocodeFactory.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        void ILoggerManager.LogDebug(string message) => logger.Debug(message);

        void ILoggerManager.LogError(string message) => logger.Error(message);

        void ILoggerManager.LogInfo(string message) => logger.Info(message);

        void ILoggerManager.LogWarning(string message) => logger.Warn(message);

    }
}
