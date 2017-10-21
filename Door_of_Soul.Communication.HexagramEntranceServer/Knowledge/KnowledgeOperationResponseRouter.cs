using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Knowledge
{
    class KnowledgeOperationResponseRouter : BasicOperationResponseRouter<KnowledgeOperationCode>
    {
        public static KnowledgeOperationResponseRouter Instance { get; private set; } = new KnowledgeOperationResponseRouter();

        private KnowledgeOperationResponseRouter() : base("Knowledge")
        {

        }
    }
}
