using Door_of_Soul.Communication.HexagramEntranceServer.Will.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Will
{
    class WillOperationResponseRouter : OperationResponseRouter<WillOperationCode>
    {
        public static WillOperationResponseRouter Instance { get; private set; } = new WillOperationResponseRouter();

        private WillOperationResponseRouter() : base("Will")
        {
            OperationTable.Add(WillOperationCode.GetWillSoul, new GetWillSoulResponseHandler());
        }
    }
}
