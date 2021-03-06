﻿using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Eternity.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public class EternityOperationRequestRouter : HexagramOperationRequestRouter<EternityEventCode, EternityOperationCode, VirtualEternity>
    {
        public EternityOperationRequestRouter() : base("HexagramNodeServerElement")
        {

        }
    }
}
