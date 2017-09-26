using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public class EndPointFactory : GenericSubjectRepository<int, TerminalEndPoint>
    {
        public static EndPointFactory Instance { get; private set; } = new EndPointFactory();

        private EndPointFactory()
        {

        }

        public bool CreateEndPoint(int endPointId, EndPointType endPointType, TerminalEndPoint.SendEventDelegate sendEventMethod, TerminalEndPoint.SendOperationResponseDelegate sendOperationResponseMethod, out TerminalEndPoint endPoint)
        {
            endPoint = new TerminalEndPoint(endPointId, endPointType, sendEventMethod, sendOperationResponseMethod);
            return Add(endPoint.EndPointId, endPoint);
        }
    }
}
