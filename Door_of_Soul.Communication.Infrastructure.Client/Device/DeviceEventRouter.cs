using Door_of_Soul.Communication.Infrastructure.Client.Device.EventHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device
{
    class DeviceEventRouter : EventRouter<Core.Device, DeviceEventCode>
    {
        public static DeviceEventRouter Instance { get; private set; } = new DeviceEventRouter();

        private DeviceEventRouter()
        {
            EventTable.Add(DeviceEventCode.SystemEvent, new SystemEventBroker());
            EventTable.Add(DeviceEventCode.AnswerEvent, new AnswerEventBroker());
            EventTable.Add(DeviceEventCode.SoulEvent, new SoulEventBroker());
            EventTable.Add(DeviceEventCode.AvatarEvent, new AvatarEventBroker());
            EventTable.Add(DeviceEventCode.WorldEvent, new WorldEventBroker());
            EventTable.Add(DeviceEventCode.SceneEvent, new SceneEventBroker());
        }
    }
}
