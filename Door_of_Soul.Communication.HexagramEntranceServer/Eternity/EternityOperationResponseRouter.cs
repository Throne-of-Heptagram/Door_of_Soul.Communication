using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Eternity
{
    class EternityOperationResponseRouter : BasicOperationResponseRouter<EternityOperationCode>
    {
        public static EternityOperationResponseRouter Instance { get; private set; } = new EternityOperationResponseRouter();

        private EternityOperationResponseRouter() : base("Eternity")
        {

        }
    }
}
