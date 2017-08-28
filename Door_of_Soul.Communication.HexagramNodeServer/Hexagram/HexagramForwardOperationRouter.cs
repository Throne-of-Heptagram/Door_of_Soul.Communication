using Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public class HexagramForwardOperationRouter : ForwardOperationRouter<HexagramForwardOperationCode>
    {
        public static HexagramForwardOperationRouter Instance { get; private set; } = new HexagramForwardOperationRouter();

        protected HexagramForwardOperationRouter() : base("HexagramCentral")
        {
            OperationTable.Add(HexagramForwardOperationCode.KnowledgeForwardOperation, new KnowledgeForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.LifeForwardOperation, new LifeForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.ElementForwardOperation, new ElementForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.InfiniteForwardOperation, new InfiniteForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.LoveForwardOperation, new LoveForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.SpaceForwardOperation, new SpaceForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.WillForwardOperation, new WillForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.ShadowForwardOperation, new ShadowForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.HistoryForwardOperation, new HistoryForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.EternityForwardOperation, new EternityForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.DestinyForwardOperation, new DestinyForwardOperationBroker());
            OperationTable.Add(HexagramForwardOperationCode.ThroneForwardOperation, new ThroneForwardOperationBroker());
        }
    }
}
