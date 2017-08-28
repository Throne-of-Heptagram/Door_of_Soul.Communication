using Door_of_Soul.Communication.HexagramEntranceServer.Space.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Space
{
    class SpaceOperationResponseRouter : OperationResponseRouter<SpaceOperationCode>
    {
        public static SpaceOperationResponseRouter Instance { get; private set; } = new SpaceOperationResponseRouter();

        private SpaceOperationResponseRouter() : base("Space")
        {
            OperationTable.Add(SpaceOperationCode.WorldOperation, new WorldOperationResponseBroker());
            OperationTable.Add(SpaceOperationCode.SceneOperation, new SceneOperationResponseBroker());
        }
    }
}
