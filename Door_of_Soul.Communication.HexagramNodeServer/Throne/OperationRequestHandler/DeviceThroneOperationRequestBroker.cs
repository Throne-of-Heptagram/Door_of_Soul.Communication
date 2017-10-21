using Door_of_Soul.Communication.HexagramNodeServer.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.OperationRequestHandler
{
    class DeviceThroneOperationRequestBroker : SubjectOperationRequestHandler<ThroneHexagramEntrance, VirtualThrone>
    {
        public DeviceThroneOperationRequestBroker() : base(typeof(DeviceThroneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(ThroneHexagramEntrance terminal, VirtualThrone target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.SendOperationResponse(terminal, ThroneOperationCode.DeviceThroneOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(ThroneHexagramEntrance terminal, VirtualThrone requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, requester, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int endPointId = (int)parameters[(byte)DeviceThroneOperationRequestParameterCode.EndPointId];
                int deviceId = (int)parameters[(byte)DeviceThroneOperationRequestParameterCode.DeviceId];
                DeviceThroneOperationCode resolvedOperationCode = (DeviceThroneOperationCode)parameters[(byte)DeviceThroneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceThroneOperationRequestParameterCode.Parameters];
                returnCode = DeviceThroneOperationRequestRouter.Instance.Route(
                    terminal: terminal,
                    l2TerminalId: endPointId,
                    l3TerminalId: deviceId,
                    subject: requester,
                    operationCode: resolvedOperationCode,
                    parameters: resolvedParameters,
                    errorMessage: out errorMessage);
            }
            return returnCode;
        }
    }
}
