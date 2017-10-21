using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initialize(CommunicationService instance)
        {
            Instance = instance;
        }

        public OperationReturnCode HandleOperationRequest(TerminalEndPoint endPoint, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return EndPointOperationRequestRouter.Instance.Route(endPoint, operationCode, parameters, out errorMessage);
        }
    }
}
