using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Scene
{
    class SceneOperationRequestRouter : L2SubjectOperationRequestRouter<TerminalEndPoint, int, VirtualScene, SceneOperationCode>
    {
        public static SceneOperationRequestRouter Instance { get; private set; } = new SceneOperationRequestRouter();

        private SceneOperationRequestRouter() : base("HexagramEntranceServerScene")
        {

        }
    }
}
