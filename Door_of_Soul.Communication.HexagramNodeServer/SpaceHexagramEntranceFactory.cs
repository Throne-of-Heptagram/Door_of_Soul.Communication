using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class SpaceHexagramEntranceFactory : GenericSubjectRepository<int, SpaceHexagramEntrance>
    {
        public static SpaceHexagramEntranceFactory Instance { get; private set; } = new SpaceHexagramEntranceFactory();

        private SpaceHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, SpaceHexagramEntrance.SendEventDelegate sendEventMethod, SpaceHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, SpaceHexagramEntrance.SendInverseOperationRequestDelegate sendInverseOperationRequestMethod, out SpaceHexagramEntrance entrance)
        {
            entrance = new SpaceHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
