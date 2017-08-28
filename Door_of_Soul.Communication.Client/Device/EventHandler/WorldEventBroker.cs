using Door_of_Soul.Communication.Client.World;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class WorldEventBroker : EventHandler<DeviceEventCode>
    {
        public WorldEventBroker() : base(typeof(WorldEventParameterCode))
        {
        }

        public override bool Handle(DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)WorldEventParameterCode.WorldId];
                WorldEventCode resolvedEventCode = (WorldEventCode)parameters[(byte)WorldEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)WorldEventParameterCode.Parameters];
                Core.World world;
                if (CommunicationService.Instance.FindWorld(worldId, out world))
                {
                    return WorldEventRouter.Instance.Route(world, resolvedEventCode, resolvedParameters, out errorMessage);
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
