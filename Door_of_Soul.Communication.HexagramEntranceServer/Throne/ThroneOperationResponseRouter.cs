using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    class ThroneOperationResponseRouter : OperationResponseRouter<ThroneOperationCode>
    {
        public static ThroneOperationResponseRouter Instance { get; private set; } = new ThroneOperationResponseRouter();

        private ThroneOperationResponseRouter() : base("Throne")
        {

        }
    }
}
