using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space.Scene
{
    class SceneOperationRequestRouter : OperationRequestRouter<TerminalHexagramEntrance, int, int, Core.Scene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter()
        {

        }
    }
}
