using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Infinite
{
    class InfiniteOperationResponseRouter : BasicOperationResponseRouter<InfiniteOperationCode>
    {
        public static InfiniteOperationResponseRouter Instance { get; private set; } = new InfiniteOperationResponseRouter();

        private InfiniteOperationResponseRouter() : base("Infinite")
        {

        }
    }
}
