using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningManagementServices.Contract
{
    public interface ILogger
    {
        void LogError(Exception ex);
    }
}
