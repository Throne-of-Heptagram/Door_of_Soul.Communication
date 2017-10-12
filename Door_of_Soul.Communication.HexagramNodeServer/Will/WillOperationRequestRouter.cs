using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public class WillOperationRequestRouter : HexagramOperationRequestRouter<WillHexagramEntrance, VirtualWill, WillOperationCode>
    {
        public WillOperationRequestRouter() : base("HexagramNodeServerWill")
        {

        }
    }
}
