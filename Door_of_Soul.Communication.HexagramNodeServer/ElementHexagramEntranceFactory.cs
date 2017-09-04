using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ElementHexagramEntranceFactory : GenericSubjectRepository<int, ElementHexagramEntrance>
    {
        public static ElementHexagramEntranceFactory Instance { get; private set; } = new ElementHexagramEntranceFactory();

        private int entranceCounter = 1;
        private object entranceCounterLock = new object();

        private ElementHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(ElementHexagramEntrance.SendEventDelegate sendEventMethod, ElementHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out ElementHexagramEntrance entrance)
        {
            lock (entranceCounterLock)
            {
                entrance = new ElementHexagramEntrance(entranceCounter, sendEventMethod, sendOperationResponseMethod);
                entranceCounter++;
                return Add(entrance.HexagramEntranceId, entrance);
            }
        }
    }
}
