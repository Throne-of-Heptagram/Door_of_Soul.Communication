using Door_of_Soul.Communication.Infrastructure.Client.World;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.OperationResponseHandler
{
    class WorldOperationResponseBroker : OperationResponseHandler<Core.Device, DeviceOperationCode>
    {
        public WorldOperationResponseBroker() : base(typeof(WorldOperationResponseParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)WorldOperationResponseParameterCode.WorldId];
                WorldOperationCode worldOperationCode = (WorldOperationCode)parameters[(byte)WorldOperationResponseParameterCode.OperationCode];
                OperationReturnCode answerOperationReturnCode = (OperationReturnCode)parameters[(byte)WorldOperationResponseParameterCode.OperationReturnCode];
                string worldOperationMessage = (string)parameters[(byte)WorldOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)WorldOperationResponseParameterCode.Parameters];
                Core.World world;
                if (CommunicationService.Instance.FindWorld(worldId, out world))
                {
                    return WorldOperationResponseRouter.Instance.Route(world, worldOperationCode, answerOperationReturnCode, worldOperationMessage, operationResponseParameters, out errorMessage);
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
