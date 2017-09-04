using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LoveHexagramEntranceFactory : GenericSubjectRepository<int, LoveHexagramEntrance>
    {
        public static LoveHexagramEntranceFactory Instance { get; private set; } = new LoveHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private LoveHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(LoveHexagramEntrance.SendEventDelegate sendEventMethod, LoveHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out LoveHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new LoveHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
