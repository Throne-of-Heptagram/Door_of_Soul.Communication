using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Communication.SceneServer.World;
using Door_of_Soul.Core.SceneServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.EndPoint.EventHandler
{
    class WorldEventBroker : EventHandler<EndPointEventCode>
    {
        public WorldEventBroker() : base(typeof(WorldEventParameterCode))
        {
        }

        public override bool Handle(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)WorldEventParameterCode.WorldId];
                WorldEventCode resolvedEventCode = (WorldEventCode)parameters[(byte)WorldEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)WorldEventParameterCode.Parameters];
                VirtualWorld world;
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
