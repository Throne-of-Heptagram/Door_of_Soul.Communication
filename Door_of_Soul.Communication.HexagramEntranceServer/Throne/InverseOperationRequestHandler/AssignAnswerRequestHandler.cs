using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.InverseOperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.InverseOperationRequestHandler
{
    class AssignAnswerRequestHandler : InverseOperationRequestHandler<ThroneInverseOperationCode>
    {
        public AssignAnswerRequestHandler() : base(typeof(AssignAnswerRequestParameterCode))
        {
        }

        public override void SendResponse(ThroneInverseOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendEndPointOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(ThroneInverseOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)AssignAnswerRequestParameterCode.AnswerId];
                OperationReturnCode returnCode = VirtualSystem.Instance.GetAnswerTrinityServer(answerId, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    SendResponse(operationCode, returnCode, errorMessage, new Dictionary<byte, object>());
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
