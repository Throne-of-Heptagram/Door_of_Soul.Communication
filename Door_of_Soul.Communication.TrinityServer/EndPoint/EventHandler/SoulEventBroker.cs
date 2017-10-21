using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.TrinityServer.Soul;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;
using Door_of_Soul.Core.Protocol;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.EventHandler
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
                if (ResourceService.Instance.FindSoul(soulId, out soul))
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
