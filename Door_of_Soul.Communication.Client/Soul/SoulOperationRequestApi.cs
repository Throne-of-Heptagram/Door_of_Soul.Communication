using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendOperationRequest(Core.Soul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (sender.Answer == null)
                return;
            DeviceOperationRequestApi.SoulOperationRequest(sender.Answer.AnswerId, sender.SoulId, operationCode, parameters);
        }
    }
}
