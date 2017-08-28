﻿using Door_of_Soul.Communication.Protocol.Internal.Scene;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    class SceneOperationResponseRouter : OperationResponseRouter<TerminalScene, SceneOperationCode>
    {
        public static SceneOperationResponseRouter Instance { get; private set; } = new SceneOperationResponseRouter();

        private SceneOperationResponseRouter()
        {
        }
    }
}
