using Door_of_Soul.Communication.Client.Soul;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class SoulEventBroker : BasicEventHandler
    {
        public SoulEventBroker() : base(typeof(SoulEventParameterCode))
        {
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int soulId = (int)parameters[(byte)SoulEventParameterCode.SoulId];
                SoulEventCode resolvedEventCode = (SoulEventCode)parameters[(byte)SoulEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SoulEventParameterCode.Parameters];
                VirtualSoul soul;
                if (CommunicationService.Instance.FindSoul(soulId, out soul))
                {
                    returnCode = SoulEventRouter.Instance.Route(soul, resolvedEventCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SoulId:{soulId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
