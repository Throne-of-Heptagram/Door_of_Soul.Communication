using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class KnowledgeHexagramEntranceFactory : GenericSubjectRepository<int, KnowledgeHexagramEntrance>
    {
        public static KnowledgeHexagramEntranceFactory Instance { get; private set; } = new KnowledgeHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private KnowledgeHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(KnowledgeHexagramEntrance.SendEventDelegate sendEventMethod, KnowledgeHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out KnowledgeHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new KnowledgeHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
