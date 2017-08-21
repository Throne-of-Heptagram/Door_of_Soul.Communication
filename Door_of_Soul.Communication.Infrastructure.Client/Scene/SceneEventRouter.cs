using Door_of_Soul.Communication.Protocol.External.Scene;

namespace Door_of_Soul.Communication.Infrastructure.Client.Scene
{
    class SceneEventRouter : EventRouter<Core.Scene, SceneEventCode>
    {
        public static SceneEventRouter Instance { get; private set; } = new SceneEventRouter();

        private SceneEventRouter()
        {
        }
    }
}
