using Door_of_Soul.Communication.Infrastructure.ExternalServer.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint.OperationResponseHandler
{
    class AvatarOperationResponseBroker : OperationResponseHandler<Core.InternalServer.EndPoint, Core.InternalServer.EndPoint, EndPointOperationCode>
    {
        public AvatarOperationResponseBroker() : base(typeof(AvatarOperationResponseParameterCode))
        {
        }

        public override bool Handle(Core.InternalServer.EndPoint terminal, Core.InternalServer.EndPoint subject, EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)AvatarOperationResponseParameterCode.AvatarId];
                AvatarOperationCode avatarOperationCode = (AvatarOperationCode)parameters[(byte)AvatarOperationResponseParameterCode.OperationCode];
                OperationReturnCode avatarOperationReturnCode = (OperationReturnCode)parameters[(byte)AvatarOperationResponseParameterCode.OperationReturnCode];
                string avatarOperationMessage = (string)parameters[(byte)AvatarOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)AvatarOperationResponseParameterCode.Parameters];
                Core.Avatar avatar;
                if (CommunicationService.Instance.FindAvatar(avatarId, out avatar))
                {
                    return AvatarOperationResponseRouter.Instance.Route(terminal, avatar, avatarOperationCode, avatarOperationReturnCode, avatarOperationMessage, operationResponseParameters, out errorMessage);
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
