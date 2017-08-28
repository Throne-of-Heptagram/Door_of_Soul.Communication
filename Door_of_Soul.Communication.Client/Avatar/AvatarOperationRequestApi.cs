using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.Client.Avatar
{
    public static class AvatarOperationRequestApi
    {
        public static void SendOperationRequest(Core.Avatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Core.Soul soul = null;
            if (!sender.SoulIds.Any(x => CommunicationService.Instance.FindSoul(x, out soul) && soul.AnswerId != 0))
                return;
            DeviceOperationRequestApi.AvatarOperationRequest(soul.AnswerId, soul.SoulId, sender.AvatarId, operationCode, parameters);
        }
    }
}
