﻿using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.HexagramNodeServer.Throne.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public class ThroneOperationRequestRouter : HexagramOperationRequestRouter<ThroneEventCode, ThroneOperationCode, VirtualThrone>
    {
        public ThroneOperationRequestRouter()
        {
            OperationTable.Add(ThroneOperationCode.GetThroneAnswer, new GetThroneAnswerRequestHandler());
        }
    }
}
