using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Destiny
{
    class DestinyOperationResponseRouter : OperationResponseRouter<DestinyOperationCode>
    {
        public static DestinyOperationResponseRouter Instance { get; private set; } = new DestinyOperationResponseRouter();

        private DestinyOperationResponseRouter() : base("Destiny")
        {

        }
    }
}
