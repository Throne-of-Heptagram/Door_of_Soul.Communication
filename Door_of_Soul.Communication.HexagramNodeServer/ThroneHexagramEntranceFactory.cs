using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ThroneHexagramEntranceFactory : GenericSubjectRepository<int, ThroneHexagramEntrance>
    {
        public static ThroneHexagramEntranceFactory Instance { get; private set; } = new ThroneHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private ThroneHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(ThroneHexagramEntrance.SendEventDelegate sendEventMethod, ThroneHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out ThroneHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new ThroneHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
