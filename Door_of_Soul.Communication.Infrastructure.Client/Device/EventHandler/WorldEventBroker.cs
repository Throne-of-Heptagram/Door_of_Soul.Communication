using Door_of_Soul.Communication.Infrastructure.Client.World;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.EventHandler
{
    class WorldEventBroker : EventHandler<Core.Device, DeviceEventCode>
    {
        public WorldEventBroker() : base(typeof(WorldEventParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)WorldEventParameterCode.WorldId];
                WorldEventCode worldEventCode = (WorldEventCode)parameters[(byte)WorldEventParameterCode.EventCode];
                Dictionary<byte, object> eventParameters = (Dictionary<byte, object>)parameters[(byte)WorldEventParameterCode.Parameters];
                Core.World world;
                if (CommunicationService.Instance.FindWorld(worldId, out world))
                {
                    return WorldEventRouter.Instance.Route(world, worldEventCode, eventParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find WorldId:{worldId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
