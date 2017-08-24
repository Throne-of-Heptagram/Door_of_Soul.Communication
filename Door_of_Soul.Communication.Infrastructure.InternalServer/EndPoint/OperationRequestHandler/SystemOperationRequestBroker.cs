using Door_of_Soul.Communication.Infrastructure.InternalServer.System;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint.OperationRequestHandler
{
    class SystemOperationRequestBroker : OperationRequestHandler<Core.Internal.EndPoint, Core.Internal.EndPoint, EndPointOperationCode>
    {
        public SystemOperationRequestBroker() : base(typeof(SystemOperationRequestParameterCode))
        {
        }

        public override void SendResponse(Core.Internal.EndPoint terminal, Core.Internal.EndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(Core.Internal.EndPoint terminal, Core.Internal.EndPoint requester, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)SystemOperationRequestParameterCode.DeviceId];
                SystemOperationCode systemOperationCode = (SystemOperationCode)parameters[(byte)SystemOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)SystemOperationRequestParameterCode.Parameters];
                return SystemOperationRequestRouter.Instance.Route(terminal, deviceId, Core.System.Instance, systemOperationCode, operationRequestParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
