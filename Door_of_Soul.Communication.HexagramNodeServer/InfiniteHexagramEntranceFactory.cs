using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class InfiniteHexagramEntranceFactory : GenericSubjectRepository<int, InfiniteHexagramEntrance>
    {
        public static InfiniteHexagramEntranceFactory Instance { get; private set; } = new InfiniteHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private InfiniteHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(InfiniteHexagramEntrance.SendEventDelegate sendEventMethod, InfiniteHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out InfiniteHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new InfiniteHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
