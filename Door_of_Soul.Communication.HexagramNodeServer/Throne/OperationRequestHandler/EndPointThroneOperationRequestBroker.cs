using Door_of_Soul.Communication.HexagramNodeServer.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.OperationRequestHandler
{
    class EndPointThroneOperationRequestBroker : SubjectOperationRequestHandler<ThroneHexagramEntrance, VirtualThrone>
    {
        public EndPointThroneOperationRequestBroker() : base(typeof(EndPointThroneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(ThroneHexagramEntrance terminal, VirtualThrone target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.SendOperationResponse(terminal, ThroneOperationCode.EndPointThroneOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(ThroneHexagramEntrance terminal, VirtualThrone requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, requester, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int endPointId = (int)parameters[(byte)EndPointThroneOperationRequestParameterCode.EndPointId];
                EndPointThroneOperationCode resolvedOperationCode = (EndPointThroneOperationCode)parameters[(byte)EndPointThroneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointThroneOperationRequestParameterCode.Parameters];
                returnCode = EndPointThroneOperationRequestRouter.Instance.Route(
                    terminal: terminal,
                    l2TerminalId: endPointId,
                    subject: requester,
                    operationCode: resolvedOperationCode,
                    parameters: resolvedParameters,
                    errorMessage: out errorMessage);
            }
            return returnCode;
        }
    }
}
