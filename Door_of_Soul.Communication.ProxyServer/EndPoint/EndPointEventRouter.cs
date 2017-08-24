using Door_of_Soul.Communication.ProxyServer.EndPoint.EventHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint
{
    class EndPointEventRouter : EventRouter<Core.Internal.EndPoint, EndPointEventCode>
    {
        public static EndPointEventRouter Instance { get; private set; } = new EndPointEventRouter();

        private EndPointEventRouter()
        {
            EventTable.Add(EndPointEventCode.SystemEvent, new SystemEventBroker());
            EventTable.Add(EndPointEventCode.AnswerEvent, new AnswerEventBroker());
            EventTable.Add(EndPointEventCode.SoulEvent, new SoulEventBroker());
            EventTable.Add(EndPointEventCode.AvatarEvent, new AvatarEventBroker());
        }
    }
}
