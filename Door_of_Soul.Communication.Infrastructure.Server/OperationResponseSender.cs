using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Server
{
    public delegate void OperationResponseSender<TOperationCode>(TOperationCode operationCode, OperationReturnCode errorCode, string operationMessage, Dictionary<byte, object> parameters);
}
