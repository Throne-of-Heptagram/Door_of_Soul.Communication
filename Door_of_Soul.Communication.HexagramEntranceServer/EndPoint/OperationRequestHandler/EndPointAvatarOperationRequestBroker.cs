using Door_of_Soul.Communication.HexagramEntranceServer.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class EndPointAvatarOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public EndPointAvatarOperationRequestBroker() : base(typeof(EndPointAvatarOperationRequestParameterCode))
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
                int avatarId = (int)parameters[(byte)EndPointAvatarOperationRequestParameterCode.AvatarId];
                AvatarOperationCode resolvedOperationCode = (AvatarOperationCode)parameters[(byte)EndPointAvatarOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointAvatarOperationRequestParameterCode.Parameters];
                VirtualAvatar avatar;
                if (ResourceService.Instance.FindAvatar(avatarId, out avatar))
                {
                    return AvatarOperationRequestRouter.Instance.Route(terminal, avatar, resolvedOperationCode, resolvedParameters, out errorMessage);
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
