using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram.OperationForwardParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRequestHandler
{
    class ThroneForwardOperationBroker : ForwardOperationHandler<HexagramForwardOperationCode>
    {
        public ThroneForwardOperationBroker() : base(typeof(OperationForwardParameterCode))
        {
        }

        public override bool Handle(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, parameters, out errorMessage))
            {
                ThroneForwardOperationCode resolvedOperationCode = (ThroneForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                return OperationRouter.ThroneForwardOperationRouter.Instance.Route(resolvedOperationCode, resolvedParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
