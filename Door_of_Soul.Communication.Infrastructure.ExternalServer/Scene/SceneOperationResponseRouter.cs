using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene
{
    class SceneOperationResponseRouter : OperationResponseRouter<Core.InternalServer.EndPoint, Core.Scene, SceneOperationCode>
    {
        public static SceneOperationResponseRouter Instance { get; private set; } = new SceneOperationResponseRouter();

        private SceneOperationResponseRouter()
        {
        }
    }
}
