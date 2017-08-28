using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Love
{
    class LoveOperationResponseRouter : OperationResponseRouter<LoveOperationCode>
    {
        public static LoveOperationResponseRouter Instance { get; private set; } = new LoveOperationResponseRouter();

        private LoveOperationResponseRouter() : base("Love")
        {

        }
    }
}
