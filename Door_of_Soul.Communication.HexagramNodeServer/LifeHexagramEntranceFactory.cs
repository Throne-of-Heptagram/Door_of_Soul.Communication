using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LifeHexagramEntranceFactory : GenericSubjectRepository<int, LifeHexagramEntrance>
    {
        public static LifeHexagramEntranceFactory Instance { get; private set; } = new LifeHexagramEntranceFactory();

        private LifeHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, LifeHexagramEntrance.SendEventDelegate sendEventMethod, LifeHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, out LifeHexagramEntrance entrance)
        {
            entrance = new LifeHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
