using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class HistoryHexagramEntranceFactory : GenericSubjectRepository<int, HistoryHexagramEntrance>
    {
        public static HistoryHexagramEntranceFactory Instance { get; private set; } = new HistoryHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private HistoryHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(HistoryHexagramEntrance.SendEventDelegate sendEventMethod, HistoryHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out HistoryHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new HistoryHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
