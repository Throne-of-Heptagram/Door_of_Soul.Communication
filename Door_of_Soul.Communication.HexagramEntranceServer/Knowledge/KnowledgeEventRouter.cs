using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Knowledge
{
    class KnowledgeEventRouter : EventRouter<KnowledgeEventCode>
    {
        public static KnowledgeEventRouter Instance { get; private set; } = new KnowledgeEventRouter();

        private KnowledgeEventRouter() : base("Knowledge")
        {

        }
    }
}
