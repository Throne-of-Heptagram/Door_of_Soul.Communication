using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramCentralServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initialize(CommunicationService instance)
        {
            Instance = instance;
        }
        public void HandleForwardOperationRequest(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            SendForwardOperation(operationCode, parameters);
        }
        public abstract void SendForwardOperation(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
