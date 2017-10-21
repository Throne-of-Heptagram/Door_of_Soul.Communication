using Door_of_Soul.Communication.Client.World;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class WorldEventBroker : BasicEventHandler
    {
        public WorldEventBroker() : base(typeof(WorldEventParameterCode))
        {
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int worldId = (int)parameters[(byte)WorldEventParameterCode.WorldId];
                WorldEventCode resolvedEventCode = (WorldEventCode)parameters[(byte)WorldEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)WorldEventParameterCode.Parameters];
                VirtualWorld world;
                if (CommunicationService.Instance.FindWorld(worldId, out world))
                {
                    returnCode = WorldEventRouter.Instance.Route(world, resolvedEventCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find WorldId:{worldId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
