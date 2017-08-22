using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.Infrastructure.Client.Avatar
{
    public static class AvatarOperationRequestApi
    {
        public static void SendOperationRequest(Core.Avatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (!sender.Souls.Any(x => x.Answer != null))
                return;
            Core.Soul firstSoul = sender.Souls.First(x => x.Answer != null);
            DeviceOperationRequestApi.AvatarOperationRequest(firstSoul.Answer.AnswerId, firstSoul.SoulId, sender.AvatarId, operationCode, parameters);
        }
    }
}
