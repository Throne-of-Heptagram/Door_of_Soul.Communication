﻿using Door_of_Soul.Communication.HexagramEntranceServer.Shadow;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class ShadowCommunicationService : HexagramCommunicationService
    {
        public static ShadowCommunicationService Instance { get; private set; }
        public static void Initialize(ShadowCommunicationService instance)
        {
            Instance = instance;
        }

        public bool HandleEvent(ShadowEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return ShadowEventRouter.Instance.Route(eventCode, parameters, out errorMessage);
        }
        public bool HandleOperationResponse(ShadowOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return ShadowOperationResponseRouter.Instance.Route(operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract void SendOperation(ShadowOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
