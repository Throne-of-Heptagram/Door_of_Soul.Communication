using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ElementHexagramEntranceFactory : GenericSubjectRepository<int, ElementHexagramEntrance>
    {
        public static ElementHexagramEntranceFactory Instance { get; private set; } = new ElementHexagramEntranceFactory();

        private ElementHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, ElementHexagramEntrance.SendEventDelegate sendEventMethod, ElementHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out ElementHexagramEntrance entrance)
        {
            entrance = new ElementHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
