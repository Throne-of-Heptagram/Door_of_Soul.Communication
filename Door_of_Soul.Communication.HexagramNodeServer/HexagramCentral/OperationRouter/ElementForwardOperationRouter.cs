using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class ElementForwardOperationRouter : HexagramForwardOperationRouter<ElementForwardOperationCode>
    {
        public ElementForwardOperationRouter() : base("Element")
        {
        }
    }
}
