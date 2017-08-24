using Door_of_Soul.Communication.Protocol.External.Scene;

namespace Door_of_Soul.Communication.Client.Scene
{
    class SceneOperationResponseRouter : OperationResponseRouter<Core.Scene, SceneOperationCode>
    {
        public static SceneOperationResponseRouter Instance { get; private set; } = new SceneOperationResponseRouter();

        private SceneOperationResponseRouter()
        {
        }
    }
}
