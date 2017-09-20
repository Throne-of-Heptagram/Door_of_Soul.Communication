using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.ProxyServer.Soul.OperationResponseHandler;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    class SoulOperationResponseRouter : OperationResponseRouter<VirtualSoul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter()
        {
            OperationTable.Add(SoulOperationCode.GetHexagramEntranceAvatar, new GetHexagramEntranceAvatarResponseHandler());
        }
    }
}
