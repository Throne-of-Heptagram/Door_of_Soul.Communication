using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ShadowHexagramEntranceFactory : GenericSubjectRepository<int, ShadowHexagramEntrance>
    {
        public static ShadowHexagramEntranceFactory Instance { get; private set; } = new ShadowHexagramEntranceFactory();

        private ShadowHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, ShadowHexagramEntrance.SendEventDelegate sendEventMethod, ShadowHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out ShadowHexagramEntrance entrance)
        {
            entrance = new ShadowHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
