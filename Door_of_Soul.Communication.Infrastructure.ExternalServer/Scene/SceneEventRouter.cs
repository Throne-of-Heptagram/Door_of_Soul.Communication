using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene
{
    class SceneEventRouter : EventRouter<Core.Scene, SceneEventCode>
    {
        public static SceneEventRouter Instance { get; private set; } = new SceneEventRouter();

        private SceneEventRouter()
        {
        }
    }
}
