using Door_of_Soul.Communication.HexagramEntranceServer.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class DeviceAvatarOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public DeviceAvatarOperationRequestBroker() : base(typeof(DeviceAvatarOperationRequestParameterCode))
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
                int deviceId = (int)parameters[(byte)DeviceAvatarOperationRequestParameterCode.DeviceId];
                int avatarId = (int)parameters[(byte)DeviceAvatarOperationRequestParameterCode.AvatarId];
                AvatarOperationCode resolvedOperationCode = (AvatarOperationCode)parameters[(byte)DeviceAnswerOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceAnswerOperationRequestParameterCode.Parameters];
                VirtualAvatar avatar;
                if (ResourceService.Instance.FindAvatar(avatarId, out avatar))
                {
                    return AvatarOperationRequestRouter.Instance.Route(terminal, deviceId, avatar, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find AvatarId:{avatarId}";
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
