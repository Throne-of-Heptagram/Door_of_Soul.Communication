using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public class WillOperationRequestRouter : HexagramOperationRequestRouter<WillEventCode, WillOperationCode, VirtualWill>
    {
        public WillOperationRequestRouter() : base("HexagramNodeServerWill")
        {

        }
    }
}
