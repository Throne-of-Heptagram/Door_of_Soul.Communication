using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public class LifeOperationRequestRouter : HexagramOperationRequestRouter<LifeHexagramEntrance, VirtualLife, LifeOperationCode>
    {
        public LifeOperationRequestRouter() : base("HexagramNodeServerLife")
        {

        }
    }
}
