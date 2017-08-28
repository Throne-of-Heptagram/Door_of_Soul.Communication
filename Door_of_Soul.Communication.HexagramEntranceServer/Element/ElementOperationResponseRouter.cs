using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Element
{
    class ElementOperationResponseRouter : OperationResponseRouter<ElementOperationCode>
    {
        public static ElementOperationResponseRouter Instance { get; private set; } = new ElementOperationResponseRouter();

        private ElementOperationResponseRouter() : base("Element")
        {

        }
    }
}
