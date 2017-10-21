using Door_of_Soul.Communication.Client.Avatar;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class AvatarEventBroker : BasicEventHandler
    {
        public AvatarEventBroker() : base(typeof(AvatarEventParameterCode))
        {
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int avatarId = (int)parameters[(byte)AvatarEventParameterCode.AvatarId];
                AvatarEventCode resolvedEventCode = (AvatarEventCode)parameters[(byte)AvatarEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AvatarEventParameterCode.Parameters];
                VirtualAvatar avatar;
                if (CommunicationService.Instance.FindAvatar(avatarId, out avatar))
                {
                    returnCode = AvatarEventRouter.Instance.Route(avatar, resolvedEventCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find AvatarId:{avatarId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
