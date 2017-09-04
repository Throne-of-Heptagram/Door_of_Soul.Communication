using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Knowledge.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public class KnowledgeOperationRequestRouter : HexagramOperationRequestRouter<KnowledgeEventCode, KnowledgeOperationCode>
    {
        public KnowledgeOperationRequestRouter() : base("Knowledge")
        {

        }
    }
}
