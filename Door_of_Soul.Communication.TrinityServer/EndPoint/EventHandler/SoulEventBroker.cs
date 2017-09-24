using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.TrinityServer.Soul;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.EventHandler
{
    class SoulEventBroker : EventHandler<EndPointEventCode>
    {
        public SoulEventBroker() : base(typeof(SoulEventParameterCode))
        {
        }

        public override bool Handle(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)SoulEventParameterCode.SoulId];
                SoulEventCode resolvedEventCode = (SoulEventCode)parameters[(byte)SoulEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SoulEventParameterCode.Parameters];
                VirtualSoul soul;
                if (ResourceService.Instance.FindSoul(soulId, out soul))
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
