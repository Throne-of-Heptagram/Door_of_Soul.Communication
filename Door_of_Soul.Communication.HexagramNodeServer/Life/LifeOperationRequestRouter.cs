using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Life.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    class LifeOperationRequestRouter : HexagramOperationRequestRouter<LifeOperationCode>
    {
        private LifeOperationRequestRouter() : base("Life")
        {

        }
    }
}
