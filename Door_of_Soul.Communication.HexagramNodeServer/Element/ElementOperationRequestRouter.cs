using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Element.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramNodeServer.Element
{
    class ElementOperationRequestRouter : HexagramOperationRequestRouter<ElementEventCode, ElementOperationCode>
    {
        private ElementOperationRequestRouter() : base("Element")
        {

        }
    }
}
