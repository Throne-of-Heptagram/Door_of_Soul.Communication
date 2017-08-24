﻿using Door_of_Soul.Communication.SceneServer.Device.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.SceneServer.Device
{
    class DeviceOperationRequestRouter : OperationRequestRouter<TerminalDevice, TerminalDevice, DeviceOperationCode>
    {
        public static DeviceOperationRequestRouter Instance { get; private set; } = new DeviceOperationRequestRouter();

        private DeviceOperationRequestRouter()
        {
            OperationTable.Add(DeviceOperationCode.SystemOperation, new SystemOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.WorldOperation, new WorldOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.SceneOperation, new SceneOperationRequestBroker());
        }
    }
}