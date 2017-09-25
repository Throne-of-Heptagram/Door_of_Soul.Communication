using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class WillHexagramEntranceFactory : GenericSubjectRepository<int, WillHexagramEntrance>
    {
        public static WillHexagramEntranceFactory Instance { get; private set; } = new WillHexagramEntranceFactory();

        private WillHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, WillHexagramEntrance.SendEventDelegate sendEventMethod, WillHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out WillHexagramEntrance entrance)
        {
            entrance = new WillHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
