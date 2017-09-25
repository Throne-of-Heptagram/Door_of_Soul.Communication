using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class KnowledgeHexagramEntranceFactory : GenericSubjectRepository<int, KnowledgeHexagramEntrance>
    {
        public static KnowledgeHexagramEntranceFactory Instance { get; private set; } = new KnowledgeHexagramEntranceFactory();

        private KnowledgeHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, KnowledgeHexagramEntrance.SendEventDelegate sendEventMethod, KnowledgeHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out KnowledgeHexagramEntrance entrance)
        {
            entrance = new KnowledgeHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
