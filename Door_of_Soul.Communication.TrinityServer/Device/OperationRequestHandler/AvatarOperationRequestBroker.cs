using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.TrinityServer.Avatar;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Device.OperationRequestHandler
{
    class AvatarOperationRequestBroker : OperationRequestHandler<TerminalDevice, DeviceOperationCode>
    {
        public AvatarOperationRequestBroker() : base(typeof(AvatarOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalDevice terminal, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)AvatarOperationRequestParameterCode.AnswerId];
                int soulId = (int)parameters[(byte)AvatarOperationRequestParameterCode.SoulId];
                int avatarId = (int)parameters[(byte)AvatarOperationRequestParameterCode.AvatarId];
                AvatarOperationCode resolvedOperationCode = (AvatarOperationCode)parameters[(byte)AnswerOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AnswerOperationRequestParameterCode.Parameters];
                VirtualAvatar avatar;
                if (terminal.IsAnswerLinked(answerId) && 
                    terminal.Answer.IsSoulLinked(soulId) &&
                    ResourceService.Instance.FindAvatar(avatarId, out avatar) &&
                    avatar.IsSoulLinked(soulId))
                {
                    return AvatarOperationRequestRouter.Instance.Route(terminal, avatar, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find AvatarId:{avatarId} in AnswerId:{answerId}, SoulId:{soulId}";
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
