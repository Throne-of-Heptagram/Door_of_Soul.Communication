using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class CentralCommunicationService
    {
        public static CentralCommunicationService Instance { get; private set; }
        public static void Initialize(CentralCommunicationService instance)
        {
            Instance = instance;
        }

        public bool HandleForwardOperationRequest(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramForwardOperationRouter.Instance.Route(operationCode, parameters, out errorMessage);
        }
        public abstract void SendForwardOperation(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
