using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.HexagramNodeServer.Space.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    class SpaceOperationRequestRouter : HexagramOperationRequestRouter<SpaceOperationCode>
    {
        private SpaceOperationRequestRouter() : base("Space")
        {
            OperationTable.Add(SpaceOperationCode.WorldOperation, new WorldOperationRequestBroker());
            OperationTable.Add(SpaceOperationCode.SceneOperation, new SceneOperationRequestBroker());
        }
    }
}
