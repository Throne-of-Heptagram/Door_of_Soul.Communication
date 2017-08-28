using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class ElementForwardOperationRouter : ForwardOperationRouter<ElementForwardOperationCode>
    {
        public static ElementForwardOperationRouter Instance { get; private set; } = new ElementForwardOperationRouter();

        public ElementForwardOperationRouter() : base("Element")
        {
        }
    }
}
