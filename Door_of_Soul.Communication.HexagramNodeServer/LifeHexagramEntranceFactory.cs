using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LifeHexagramEntranceFactory : GenericSubjectRepository<int, LifeHexagramEntrance>
    {
        public static LifeHexagramEntranceFactory Instance { get; private set; } = new LifeHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private LifeHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(LifeHexagramEntrance.SendEventDelegate sendEventMethod, LifeHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out LifeHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new LifeHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
