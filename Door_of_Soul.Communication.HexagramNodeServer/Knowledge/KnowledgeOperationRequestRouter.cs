//using Door_of_Soul.Communication.HexagramNodeServer.Knowledge.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Knowledge
{
    public class KnowledgeOperationRequestRouter : HexagramOperationRequestRouter<KnowledgeHexagramEntrance, VirtualKnowledge, KnowledgeOperationCode>
    {
        public KnowledgeOperationRequestRouter() : base("HexagramNodeServerKnowledge")
        {

        }
    }
}
