using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EternityHexagramEntranceFactory : GenericSubjectRepository<int, EternityHexagramEntrance>
    {
        public static EternityHexagramEntranceFactory Instance { get; private set; } = new EternityHexagramEntranceFactory();

        private EternityHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, EternityHexagramEntrance.SendEventDelegate sendEventMethod, EternityHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, EternityHexagramEntrance.SendInverseOperationRequestDelegate sendInverseOperationRequestMethod, out EternityHexagramEntrance entrance)
        {
            entrance = new EternityHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
