﻿using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Love.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public class LoveOperationRequestRouter : HexagramOperationRequestRouter<LoveEventCode, LoveOperationCode, VirtualLove>
    {
        public LoveOperationRequestRouter() : base("HexagramNodeServerLove")
        {

        }
    }
}
