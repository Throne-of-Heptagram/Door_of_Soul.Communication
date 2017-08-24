using Door_of_Soul.Communication.Protocol.External.Scene;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    class SceneOperationRequestRouter : OperationRequestRouter<TerminalDevice, TerminalScene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter()
        {

        }
    }
}
