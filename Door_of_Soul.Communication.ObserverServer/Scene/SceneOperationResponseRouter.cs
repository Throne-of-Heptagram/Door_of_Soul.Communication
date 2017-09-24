using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.ObserverServer.Scene
{
    class SceneOperationResponseRouter : SubjectOperationResponseRouter<TerminalScene, SceneOperationCode>
    {
        public static SceneOperationResponseRouter Instance { get; private set; } = new SceneOperationResponseRouter();

        private SceneOperationResponseRouter() : base("ObserverServerScene")
        {
        }
    }
}
