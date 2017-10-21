﻿using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class InfiniteHexagramEntranceFactory : GenericSubjectRepository<int, InfiniteHexagramEntrance>
    {
        public static InfiniteHexagramEntranceFactory Instance { get; private set; } = new InfiniteHexagramEntranceFactory();

        private InfiniteHexagramEntranceFactory()
        {

        }

        public bool CreateEntrance(int hexagranEntranceId, InfiniteHexagramEntrance.SendEventDelegate sendEventMethod, InfiniteHexagramEntrance.SendOperationResponseDelegate sendOperationResponseMethod, InfiniteHexagramEntrance.SendInverseOperationRequestDelegate sendInverseOperationRequestMethod, out InfiniteHexagramEntrance entrance)
        {
            entrance = new InfiniteHexagramEntrance(hexagranEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod);
            return Add(entrance.HexagramEntranceId, entrance);
        }
    }
}
