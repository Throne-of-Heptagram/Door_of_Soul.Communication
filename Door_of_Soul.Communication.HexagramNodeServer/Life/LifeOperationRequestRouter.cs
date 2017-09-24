using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public class LifeOperationRequestRouter : HexagramOperationRequestRouter<LifeEventCode, LifeOperationCode, VirtualLife>
    {
        public LifeOperationRequestRouter() : base("HexagramNodeServerLife")
        {

        }
    }
}
