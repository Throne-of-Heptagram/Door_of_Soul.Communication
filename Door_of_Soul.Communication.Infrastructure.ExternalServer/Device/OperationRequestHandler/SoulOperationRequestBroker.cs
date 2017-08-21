using Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device.OperationRequestHandler
{
    class SoulOperationRequestBroker : OperationRequestHandler<Core.Device, DeviceOperationCode>
    {
        public SoulOperationRequestBroker() : base(typeof(SoulOperationRequestParameterCode))
        {
        }

        public override void SendResponse(Core.Device target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(Core.Device requester, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(requester, operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)SoulOperationRequestParameterCode.AnswerId];
                int soulId = (int)parameters[(byte)SoulOperationRequestParameterCode.SoulId];
                SoulOperationCode soulOperationCode = (SoulOperationCode)parameters[(byte)SoulOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)SoulOperationRequestParameterCode.Parameters];
                Core.Soul soul;
                if (requester.IsAnswerLinked(answerId) && requester.Answer.FindSoul(soulId, out soul))
                {
                    return SoulOperationRequestRouter.Instance.Route(soul, soulOperationCode, operationRequestParameters, out errorMessage);
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
