using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    public class KnowledgeForwardOperationRouter : HexagramForwardOperationRouter<KnowledgeForwardOperationCode>
    {
        public KnowledgeForwardOperationRouter() : base("Knowledge")
        {
        }
    }
}
