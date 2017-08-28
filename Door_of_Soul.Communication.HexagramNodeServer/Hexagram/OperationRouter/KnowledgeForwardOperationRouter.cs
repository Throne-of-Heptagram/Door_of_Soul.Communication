using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class KnowledgeForwardOperationRouter : ForwardOperationRouter<KnowledgeForwardOperationCode>
    {
        public static KnowledgeForwardOperationRouter Instance { get; private set; } = new KnowledgeForwardOperationRouter();

        public KnowledgeForwardOperationRouter() : base("Knowledge")
        {
        }
    }
}
