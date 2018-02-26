using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolCompanyApp.Logging
{
    class XLoggerFacade : IXLoggerFacade
    {
        XLog.Logger s_logger = XLog.LogManager.Default.GetLogger("MyCoolCompanyApp");
        public void Log(string message, Category category, Priority priority)
        {
            Log(message, category, priority, null);
        }

        public void Log(string message, Category category, Priority priority, Exception ex)
        {
            switch (category)
            {
                case Category.Debug:
                    s_logger.Debug((int)priority, message,ex);
                    break;
                case Category.Exception:
                    s_logger.Error((int)priority, message,ex);
                    break;
                case Category.Info:
                    s_logger.Info((int)priority, message,ex);
                    break;
                case Category.Warn:
                    s_logger.Warn((int)priority, message,ex);
                    break;
                default:
                    break;
            }
        }
    }
}
