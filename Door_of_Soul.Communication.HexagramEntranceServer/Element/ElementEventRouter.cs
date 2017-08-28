using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Element
{
    class ElementEventRouter : EventRouter<ElementEventCode>
    {
        public static ElementEventRouter Instance { get; private set; } = new ElementEventRouter();

        private ElementEventRouter() : base("Element")
        {

        }
    }
}
