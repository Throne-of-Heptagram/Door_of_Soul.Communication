using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.ProxyServer.Avatar;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler
{
    class EndPointAvatarOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public EndPointAvatarOperationResponseBroker() : base(typeof(EndPointAvatarOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)EndPointAvatarOperationResponseParameterCode.AvatarId];
                AvatarOperationCode resolvedOperationCode = (AvatarOperationCode)parameters[(byte)EndPointAvatarOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointAvatarOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointAvatarOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointAvatarOperationResponseParameterCode.Parameters];
                VirtualAvatar avatar;
                if (ResourceService.Instance.FindAvatar(avatarId, out avatar))
                {
                    return AvatarOperationResponseRouter.Instance.Route(avatar, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
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
