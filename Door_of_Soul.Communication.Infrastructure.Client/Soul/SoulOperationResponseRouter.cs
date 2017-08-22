using Door_of_Soul.Communication.Protocol.External.Soul;

namespace Door_of_Soul.Communication.Infrastructure.Client.Soul
{
    class SoulOperationResponseRouter : OperationResponseRouter<Core.Device, Core.Soul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter()
        {
        }
    }
}
