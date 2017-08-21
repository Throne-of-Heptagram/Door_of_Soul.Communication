﻿using Door_of_Soul.Communication.Infrastructure.Client.Device.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device
{
    class DeviceOperationResponseRouter : OperationResponseRouter<Core.Device, DeviceOperationCode>
    {
        public static DeviceOperationResponseRouter Instance { get; private set; } = new DeviceOperationResponseRouter();

        private DeviceOperationResponseRouter()
        {
            OperationTable.Add(DeviceOperationCode.SystemOperation, new SystemOperationResponseBroker());
            OperationTable.Add(DeviceOperationCode.AnswerOperation, new AnswerOperationResponseBroker());
            OperationTable.Add(DeviceOperationCode.SoulOperation, new SoulOperationResponseBroker());
            OperationTable.Add(DeviceOperationCode.AvatarOperation, new AvatarOperationResponseBroker());
            OperationTable.Add(DeviceOperationCode.WorldOperation, new WorldOperationResponseBroker());
            OperationTable.Add(DeviceOperationCode.SceneOperation, new SceneOperationResponseBroker());
        }
    }
}
