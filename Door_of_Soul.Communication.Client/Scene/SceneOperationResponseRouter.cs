using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Scene
{
    class SceneOperationResponseRouter : OperationResponseRouter<VirtualScene, SceneOperationCode>
    {
        public static SceneOperationResponseRouter Instance { get; private set; } = new SceneOperationResponseRouter();

        private SceneOperationResponseRouter()
        {
        }
    }
}
