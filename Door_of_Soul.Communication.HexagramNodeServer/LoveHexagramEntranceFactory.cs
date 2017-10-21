﻿using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LoveHexagramEntranceFactory : GenericSubjectRepository<int, LoveHexagramEntrance>
    {
        public static LoveHexagramEntranceFactory Instance { get; private set; } = new LoveHexagramEntranceFactory();

        private LoveHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, LoveHexagramEntrance.SendEventDelegate sendEventMethod, LoveHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, LoveHexagramEntrance.SendInverseOperationRequestDelegate sendInverseOperationRequestMethod, out LoveHexagramEntrance entrance)
        {
            entrance = new LoveHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
