using Door_of_Soul.Core;
using System;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public class EndPointFactory : GenericSubjectRepository<int, TerminalEndPoint>
    {
        public static EndPointFactory Instance { get; private set; } = new EndPointFactory();

        private EndPointFactory()
        {

        }

        public bool CreateEndPoint(int endPointId, EndPointType endPointType, TerminalEndPoint.SendEventDelegate sendEventMethod, TerminalEndPoint.SendOperationResponseDelegate sendOperationResponseMethod, TerminalEndPoint.SendInverseOperationRequestDelegate sendInverseOperationRequestMethod, out TerminalEndPoint endPoint)
        {
            switch(endPointType)
            {
                case EndPointType.LoginServer:
                    endPoint = new LoginEndPoint(endPointId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
                    break;
                case EndPointType.TrinityServer:
                    endPoint = new TrinityEndPoint(endPointId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
                    break;
                case EndPointType.ObserverServer:
                    endPoint = new ObserverEndPoint(endPointId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
                    break;
                default:
                    throw new NotImplementedException($"EndPointFactory unknown EndPointType:{endPointType}");
            }
            return Add(endPoint.EndPointId, endPoint);
        }
        public bool Find<TEndPoint>(int endPointId, out TEndPoint endPoint) where TEndPoint : TerminalEndPoint
        {
            TerminalEndPoint baseEndPoint;
            if(Find(endPointId, out baseEndPoint) && baseEndPoint is TEndPoint)
            {
                endPoint = baseEndPoint as TEndPoint;
                return true;
            }
            else
            {
                endPoint = default(TEndPoint);
                return false;
            }
        }
    }
}
