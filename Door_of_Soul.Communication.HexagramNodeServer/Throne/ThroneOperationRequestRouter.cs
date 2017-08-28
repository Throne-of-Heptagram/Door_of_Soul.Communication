using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Throne.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    class ThroneOperationRequestRouter : HexagramOperationRequestRouter<ThroneOperationCode>
    {
        private ThroneOperationRequestRouter() : base("Throne")
        {

        }
    }
}
