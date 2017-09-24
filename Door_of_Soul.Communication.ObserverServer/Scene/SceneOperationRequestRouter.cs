using Door_of_Soul.Communication.Protocol.External.Scene;

namespace Door_of_Soul.Communication.ObserverServer.Scene
{
    class SceneOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, TerminalScene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter() : base("ObserverServerScene")
        {

        }
    }
}
