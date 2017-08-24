using Door_of_Soul.Communication.Protocol.External.Soul;

namespace Door_of_Soul.Communication.Client.Soul
{
    class SoulOperationResponseRouter : OperationResponseRouter<Core.Soul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter()
        {
        }
    }
}
