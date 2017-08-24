using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.Scene
{
    class SceneOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, int, Core.Scene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter()
        {

        }
    }
}
