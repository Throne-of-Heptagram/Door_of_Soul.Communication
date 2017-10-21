using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.TrinityServer.Soul;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Device.OperationRequestHandler
{
    class SoulOperationRequestBroker : BasicOperationRequestHandler<TerminalDevice>
    {
        public SoulOperationRequestBroker() : base(typeof(SoulOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, DeviceOperationCode.SoulOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalDevice terminal, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
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
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
