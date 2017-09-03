using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendOperationRequest(VirtualSoul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (sender.AnswerId != 0)
                return;
            DeviceOperationRequestApi.SoulOperationRequest(sender.AnswerId, sender.SoulId, operationCode, parameters);
        }
    }
}
