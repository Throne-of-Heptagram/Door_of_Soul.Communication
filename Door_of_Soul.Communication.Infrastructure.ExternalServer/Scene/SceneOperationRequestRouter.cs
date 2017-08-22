using Door_of_Soul.Communication.Protocol.External.Scene;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene
{
    class SceneOperationRequestRouter : OperationRequestRouter<Core.Device, Core.Scene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter()
        {

        }
    }
}
