using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Life
{
    class LifeOperationResponseRouter : OperationResponseRouter<LifeOperationCode>
    {
        public static LifeOperationResponseRouter Instance { get; private set; } = new LifeOperationResponseRouter();

        private LifeOperationResponseRouter() : base("Life")
        {

        }
    }
}
