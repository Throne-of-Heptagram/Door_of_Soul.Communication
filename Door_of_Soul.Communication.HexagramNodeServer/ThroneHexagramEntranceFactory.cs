using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ThroneHexagramEntranceFactory : GenericSubjectRepository<int, ThroneHexagramEntrance>
    {
        public static ThroneHexagramEntranceFactory Instance { get; private set; } = new ThroneHexagramEntranceFactory();

        private ThroneHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, ThroneHexagramEntrance.SendEventDelegate sendEventMethod, ThroneHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out ThroneHexagramEntrance entrance)
        {
            entrance = new ThroneHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
