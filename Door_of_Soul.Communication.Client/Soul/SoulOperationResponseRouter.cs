using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Soul
{
    class SoulOperationResponseRouter : SubjectOperationResponseRouter<VirtualSoul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter() : base("ClientSoul")
        {
        }
    }
}
