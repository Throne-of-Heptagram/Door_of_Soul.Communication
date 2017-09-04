using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EternityHexagramEntranceFactory : GenericSubjectRepository<int, EternityHexagramEntrance>
    {
        public static EternityHexagramEntranceFactory Instance { get; private set; } = new EternityHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private EternityHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(EternityHexagramEntrance.SendEventDelegate sendEventMethod, EternityHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out EternityHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new EternityHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
