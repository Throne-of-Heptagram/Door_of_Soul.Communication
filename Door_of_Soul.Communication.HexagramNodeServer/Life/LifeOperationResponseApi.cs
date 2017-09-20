using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Communication.Protocol.Hexagram.Life.OperationResponseParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public static class LifeOperationResponseApi
    {
        public static void SendOperationResponse(LifeHexagramEntrance target, LifeOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetLifeAvatar(LifeHexagramEntrance terminal, OperationReturnCode operationReturnCode, string operationMessage, VirtualAvatar avatar)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetLifeAvatarResponseParameterCode.AvatarId, avatar.AvatarId },
                { (byte)GetLifeAvatarResponseParameterCode.EntityId, avatar.EntityId },
                { (byte)GetLifeAvatarResponseParameterCode.AvatarName, avatar.AvatarName },
                { (byte)GetLifeAvatarResponseParameterCode.SoulIds, avatar.SoulIds.ToArray() }
            };
            SendOperationResponse(terminal, LifeOperationCode.GetLifeAvatar, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
