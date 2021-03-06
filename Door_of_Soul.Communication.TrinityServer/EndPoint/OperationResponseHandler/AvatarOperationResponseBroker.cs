﻿using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.TrinityServer.Avatar;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.OperationResponseHandler
{
    class AvatarOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public AvatarOperationResponseBroker() : base(typeof(AvatarOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)AvatarOperationResponseParameterCode.AvatarId];
                AvatarOperationCode resolvedOperationCode = (AvatarOperationCode)parameters[(byte)AvatarOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)AvatarOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)AvatarOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AvatarOperationResponseParameterCode.Parameters];
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
