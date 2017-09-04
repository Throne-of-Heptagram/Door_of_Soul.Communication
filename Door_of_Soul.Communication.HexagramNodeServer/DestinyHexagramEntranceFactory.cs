using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class DestinyHexagramEntranceFactory : GenericSubjectRepository<int, DestinyHexagramEntrance>
    {
        public static DestinyHexagramEntranceFactory Instance { get; private set; } = new DestinyHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private DestinyHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(DestinyHexagramEntrance.SendEventDelegate sendEventMethod, DestinyHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out DestinyHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new DestinyHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
