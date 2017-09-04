using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.ProxyServer.Soul;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Device.OperationRequestHandler
{
    class SoulOperationRequestBroker : OperationRequestHandler<TerminalDevice, DeviceOperationCode>
    {
        public SoulOperationRequestBroker() : base(typeof(SoulOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalDevice terminal, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)SoulOperationRequestParameterCode.AnswerId];
                int soulId = (int)parameters[(byte)SoulOperationRequestParameterCode.SoulId];
                SoulOperationCode resolvedOperationCode = (SoulOperationCode)parameters[(byte)SoulOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SoulOperationRequestParameterCode.Parameters];
                VirtualSoul soul;
                if (terminal.IsAnswerLinked(answerId) &&
                    ResourceService.Instance.FindSoul(soulId, out soul) &&
                    soul.AnswerId == answerId)
                {
                    return SoulOperationRequestRouter.Instance.Route(terminal, soul, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SoulId:{soulId} in AnswerId:{answerId}";
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
