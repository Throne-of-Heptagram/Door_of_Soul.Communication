using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Life
{
    class LifeEventRouter : BasicEventRouter<LifeEventCode>
    {
        public static LifeEventRouter Instance { get; private set; } = new LifeEventRouter();

        private LifeEventRouter() : base("Life")
        {

        }
    }
}
