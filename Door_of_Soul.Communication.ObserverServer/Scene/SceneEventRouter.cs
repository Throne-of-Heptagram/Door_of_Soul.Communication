using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.ObserverServer.Scene
{
    class SceneEventRouter : SubjectEventRouter<TerminalScene, SceneEventCode>
    {
        public static SceneEventRouter Instance { get; private set; } = new SceneEventRouter();

        private SceneEventRouter() : base("ObserverServerScene")
        {
        }
    }
}
