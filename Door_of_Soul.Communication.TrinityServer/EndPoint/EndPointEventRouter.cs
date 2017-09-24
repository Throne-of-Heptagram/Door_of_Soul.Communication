using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.TrinityServer.EndPoint.EventHandler;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint
{
    class EndPointEventRouter : EventRouter<EndPointEventCode>
    {
        public static EndPointEventRouter Instance { get; private set; } = new EndPointEventRouter();

        private EndPointEventRouter() : base("EndPoint")
        {
            EventTable.Add(EndPointEventCode.SystemEvent, new SystemEventBroker());
            EventTable.Add(EndPointEventCode.AnswerEvent, new AnswerEventBroker());
            EventTable.Add(EndPointEventCode.SoulEvent, new SoulEventBroker());
            EventTable.Add(EndPointEventCode.AvatarEvent, new AvatarEventBroker());
        }
    }
}
