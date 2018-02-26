using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolCompanyApp.Logging
{
    public interface IXLoggerFacade: ILoggerFacade
    {
        void Log(string message, Category category, Priority priority, Exception ex);
    }
}
