using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendOperationRequest(Core.Soul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (sender.AnswerId != 0)
                return;
            DeviceOperationRequestApi.SoulOperationRequest(sender.AnswerId, sender.SoulId, operationCode, parameters);
        }
    }
}
