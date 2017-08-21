using Door_of_Soul.Communication.Infrastructure.Client.Soul;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.EventHandler
{
    class SoulEventBroker : EventHandler<Core.Device, DeviceEventCode>
    {
        public SoulEventBroker() : base(typeof(SoulEventParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)SoulEventParameterCode.SoulId];
                SoulEventCode soulEventCode = (SoulEventCode)parameters[(byte)SoulEventParameterCode.EventCode];
                Dictionary<byte, object> eventParameters = (Dictionary<byte, object>)parameters[(byte)SoulEventParameterCode.Parameters];
                Core.Soul soul;
                if (CommunicationService.Instance.FindSoul(soulId, out soul))
                {
                    return SoulEventRouter.Instance.Route(soul, soulEventCode, eventParameters, out errorMessage);
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
