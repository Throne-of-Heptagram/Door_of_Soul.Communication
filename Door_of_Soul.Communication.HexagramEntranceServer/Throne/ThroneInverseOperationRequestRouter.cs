using Door_of_Soul.Communication.HexagramEntranceServer.Throne.InverseOperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    class ThroneInverseOperationRequestRouter : InverseOperationRequestRouter<ThroneInverseOperationCode>
    {
        public static ThroneInverseOperationRequestRouter Instance { get; private set; } = new ThroneInverseOperationRequestRouter();

        private ThroneInverseOperationRequestRouter() : base("HexagramEntranceServerThrone")
        {
            OperationTable.Add(ThroneInverseOperationCode.AssignAnswer, new AssignAnswerRequestHandler());
        }
    }
}
