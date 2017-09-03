using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Scene
{
    class SceneEventRouter : EventRouter<VirtualScene, SceneEventCode>
    {
        public static SceneEventRouter Instance { get; private set; } = new SceneEventRouter();

        private SceneEventRouter()
        {
        }
    }
}
