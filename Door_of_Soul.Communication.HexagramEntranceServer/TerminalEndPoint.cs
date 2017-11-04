using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class TerminalEndPoint : IEventDependencyReleasable
    {
        public delegate void SendEventDelegate(EndPointEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);
        public delegate void SendInverseOperationRequestDelegate(EndPointInverseOperationCode operationCode, Dictionary<byte, object> parameters);

        public event Action OnDisconnected;
        public event Action OnEventDependencyDisappear;

        public int EndPointId { get; private set; }

        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }
        public SendInverseOperationRequestDelegate SendInverseOperationRequest { get; private set; }

        protected TerminalEndPoint(int endPointId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod)
        {
            EndPointId = endPointId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
            SendInverseOperationRequest = sendInverseOperationRequestMethod;
        }

        public override string ToString()
        {
            return $"EndPoint Id:{EndPointId}";
        }

        public void Disconnect()
        {
            OnDisconnected?.Invoke();
            ReleaseDependency();
        }

        public void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
