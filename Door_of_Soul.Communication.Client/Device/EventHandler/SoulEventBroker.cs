using Door_of_Soul.Communication.Client.Soul;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class SoulEventBroker : EventHandler<DeviceEventCode>
    {
        public SoulEventBroker() : base(typeof(SoulEventParameterCode))
        {
        }

        public override bool Handle(DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)SoulEventParameterCode.SoulId];
                SoulEventCode resolvedEventCode = (SoulEventCode)parameters[(byte)SoulEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SoulEventParameterCode.Parameters];
                Core.Soul soul;
                if (CommunicationService.Instance.FindSoul(soulId, out soul))
                {
                    return SoulEventRouter.Instance.Route(soul, resolvedEventCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SoulId:{soulId}";
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
