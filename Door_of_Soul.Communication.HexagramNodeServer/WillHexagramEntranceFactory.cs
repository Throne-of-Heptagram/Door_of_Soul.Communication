using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class WillHexagramEntranceFactory : GenericSubjectRepository<int, WillHexagramEntrance>
    {
        public static WillHexagramEntranceFactory Instance { get; private set; } = new WillHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private WillHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(WillHexagramEntrance.SendEventDelegate sendEventMethod, WillHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out WillHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new WillHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
