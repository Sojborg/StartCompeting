using System.Reflection;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace StartCompeting.Frontend.Web.Plumping
{
    public class Log4ExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error(context.Exception);
        }
    }
}