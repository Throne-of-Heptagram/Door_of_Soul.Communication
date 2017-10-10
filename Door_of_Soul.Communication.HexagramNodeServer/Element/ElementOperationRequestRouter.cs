using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
//using Door_of_Soul.Communication.HexagramNodeServer.Element.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Element
{
    public class ElementOperationRequestRouter : HexagramOperationRequestRouter<ElementEventCode, ElementOperationCode, VirtualElement>
    {
        public ElementOperationRequestRouter() : base("HexagramNodeServerElement")
        {

        }
    }
}
