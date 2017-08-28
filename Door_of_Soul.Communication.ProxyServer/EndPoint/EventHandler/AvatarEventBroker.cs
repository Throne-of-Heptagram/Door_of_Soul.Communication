using Door_of_Soul.Communication.ProxyServer.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.EventHandler
{
    class AvatarEventBroker : EventHandler<EndPointEventCode>
    {
        public AvatarEventBroker() : base(typeof(AvatarEventParameterCode))
        {
        }

        public override bool Handle(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)AvatarEventParameterCode.AvatarId];
                AvatarEventCode resolvedEventCode = (AvatarEventCode)parameters[(byte)AvatarEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AvatarEventParameterCode.Parameters];
                Core.Avatar avatar;
                if (CommunicationService.Instance.FindAvatar(avatarId, out avatar))
                {
                    return AvatarEventRouter.Instance.Route(avatar, resolvedEventCode, resolvedParameters, out errorMessage);
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
