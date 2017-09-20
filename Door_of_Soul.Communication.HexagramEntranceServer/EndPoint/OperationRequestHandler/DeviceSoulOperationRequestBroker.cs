using Door_of_Soul.Communication.HexagramEntranceServer.Soul;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class DeviceSoulOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public DeviceSoulOperationRequestBroker() : base(typeof(DeviceSoulOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceSoulOperationRequestParameterCode.DeviceId];
                int soulId = (int)parameters[(byte)DeviceSoulOperationRequestParameterCode.SoulId];
                SoulOperationCode resolvedOperationCode = (SoulOperationCode)parameters[(byte)DeviceSoulOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceSoulOperationRequestParameterCode.Parameters];
                VirtualSoul soul;
                if (ResourceService.Instance.FindSoul(soulId, out soul))
                {
                    return SoulOperationRequestRouter.Instance.Route(terminal, deviceId, soul, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SoulId:{soulId}";
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
