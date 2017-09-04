using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class SpaceHexagramEntranceFactory : GenericSubjectRepository<int, SpaceHexagramEntrance>
    {
        public static SpaceHexagramEntranceFactory Instance { get; private set; } = new SpaceHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private SpaceHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(SpaceHexagramEntrance.SendEventDelegate sendEventMethod, SpaceHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out SpaceHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new SpaceHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
