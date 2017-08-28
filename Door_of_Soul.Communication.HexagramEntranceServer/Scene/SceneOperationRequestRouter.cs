using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Scene
{
    class SceneOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, Core.Scene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter()
        {

        }
    }
}
