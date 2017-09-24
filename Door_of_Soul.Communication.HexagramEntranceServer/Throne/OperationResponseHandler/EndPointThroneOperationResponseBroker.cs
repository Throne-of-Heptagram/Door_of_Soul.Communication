using Door_of_Soul.Communication.HexagramEntranceServer.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.OperationResponseHandler
{
    class EndPointThroneOperationResponseBroker : OperationResponseHandler<ThroneOperationCode>
    {
        public EndPointThroneOperationResponseBroker() : base(typeof(EndPointThroneOperationResponseParameterCode))
        {
        }

        public override bool Handle(ThroneOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int endPointId = (int)parameters[(byte)EndPointThroneOperationResponseParameterCode.EndPointId];
                EndPointThroneOperationCode resolvedOperationCode = (EndPointThroneOperationCode)parameters[(byte)EndPointThroneOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointThroneOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointThroneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointThroneOperationResponseParameterCode.Parameters];
                TerminalEndPoint endPoint;
                if (EndPointFactory.Instance.Find(endPointId, out endPoint))
                {
                    return EndPointThroneOperationResponseRouter.Instance.Route(endPoint, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find EndPointId:{endPointId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
