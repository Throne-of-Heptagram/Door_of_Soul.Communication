using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.InverseOperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.InverseOperationRequestHandler
{
    class AssignAnswerRequestHandler : BasicInverseOperationRequestHandler
    {
        public AssignAnswerRequestHandler() : base(typeof(AssignAnswerRequestParameterCode))
        {
        }

        public override void SendResponse(OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneInverseOperationResponseApi.SendOperationResponse(ThroneInverseOperationCode.AssignAnswer, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int answerId = (int)parameters[(byte)AssignAnswerRequestParameterCode.AnswerId];
                returnCode = VirtualSystem.Instance.AssignAnswer(answerId, out errorMessage);
            }
            return returnCode;
        }
    }
}
