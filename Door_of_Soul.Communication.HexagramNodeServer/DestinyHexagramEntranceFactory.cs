using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class DestinyHexagramEntranceFactory : GenericSubjectRepository<int, DestinyHexagramEntrance>
    {
        public static DestinyHexagramEntranceFactory Instance { get; private set; } = new DestinyHexagramEntranceFactory();

        private DestinyHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, DestinyHexagramEntrance.SendEventDelegate sendEventMethod, DestinyHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out DestinyHexagramEntrance entrance)
        {
            entrance = new DestinyHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
