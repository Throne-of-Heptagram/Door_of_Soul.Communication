using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public class EndPointFactory : GenericSubjectRepository<int, TerminalEndPoint>
    {
        public static EndPointFactory Instance { get; private set; } = new EndPointFactory();

        private int endPointCounter = 1;
        private object endPointCounterLock = new object();

        private EndPointFactory()
        {

        }

        public bool CreateDevice(EndPointType endPointType, TerminalEndPoint.SendEventDelegate sendEventMethod, TerminalEndPoint.SendOperationResponseDelegate sendOperationResponseMethod, out TerminalEndPoint endPoint)
        {
            lock (endPointCounterLock)
            {
                endPoint = new TerminalEndPoint(endPointCounter, endPointType, sendEventMethod, sendOperationResponseMethod);
                endPointCounter++;
                return Add(endPoint.EndPointId, endPoint);
            }
        }
    }
}
