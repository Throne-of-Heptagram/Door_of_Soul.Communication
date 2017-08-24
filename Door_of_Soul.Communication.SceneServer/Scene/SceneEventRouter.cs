using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    class SceneEventRouter : EventRouter<TerminalScene, SceneEventCode>
    {
        public static SceneEventRouter Instance { get; private set; } = new SceneEventRouter();

        private SceneEventRouter()
        {
        }
    }
}
