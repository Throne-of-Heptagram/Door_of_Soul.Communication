using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram.OperationForwardParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRequestHandler
{
    class ShadowForwardOperationBroker : ForwardOperationHandler<HexagramForwardOperationCode>
    {
        public ShadowForwardOperationBroker() : base(typeof(OperationForwardParameterCode))
        {
        }

        public override bool Handle(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, parameters, out errorMessage))
            {
                ShadowForwardOperationCode resolvedOperationCode = (ShadowForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                return OperationRouter.ShadowForwardOperationRouter.Instance.Route(resolvedOperationCode, resolvedParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
