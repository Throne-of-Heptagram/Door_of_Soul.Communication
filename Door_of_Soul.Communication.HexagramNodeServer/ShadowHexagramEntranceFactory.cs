using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ShadowHexagramEntranceFactory : GenericSubjectRepository<int, ShadowHexagramEntrance>
    {
        public static ShadowHexagramEntranceFactory Instance { get; private set; } = new ShadowHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private ShadowHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(ShadowHexagramEntrance.SendEventDelegate sendEventMethod, ShadowHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out ShadowHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new ShadowHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
