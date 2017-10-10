using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class LifeForwardOperationRouter : HexagramForwardOperationRouter<LifeForwardOperationCode>
    {
        public LifeForwardOperationRouter() : base("Life")
        {
        }
    }
}
