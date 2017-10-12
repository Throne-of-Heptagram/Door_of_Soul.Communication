using Door_of_Soul.Communication.HexagramNodeServer.Throne.InverseOperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    class ThroneInverseOperationResponseRouter : SubjectInverseOperationResponseRouter<ThroneHexagramEntrance, VirtualThrone, ThroneInverseOperationCode>
    {
        public static ThroneInverseOperationResponseRouter Instance { get; private set; } = new ThroneInverseOperationResponseRouter();

        private ThroneInverseOperationResponseRouter() : base("HexagramNodeServerThroneInverse")
        {
            OperationTable.Add(ThroneInverseOperationCode.AssignAnswer, new AssignAnswerResponseHandler());
        }
    }
}
