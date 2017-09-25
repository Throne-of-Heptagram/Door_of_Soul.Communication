using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class HistoryHexagramEntranceFactory : GenericSubjectRepository<int, HistoryHexagramEntrance>
    {
        public static HistoryHexagramEntranceFactory Instance { get; private set; } = new HistoryHexagramEntranceFactory();

        private HistoryHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, HistoryHexagramEntrance.SendEventDelegate sendEventMethod, HistoryHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out HistoryHexagramEntrance entrance)
        {
            entrance = new HistoryHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
