using Door_of_Soul.Communication.SceneServer.EndPoint.EventHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.SceneServer.EndPoint
{
    class EndPointEventRouter : EventRouter<EndPointEventCode>
    {
        public static EndPointEventRouter Instance { get; private set; } = new EndPointEventRouter();

        private EndPointEventRouter() : base("EndPoint")
        {
            EventTable.Add(EndPointEventCode.SystemEvent, new SystemEventBroker());
            EventTable.Add(EndPointEventCode.WorldEvent, new WorldEventBroker());
            EventTable.Add(EndPointEventCode.SceneEvent, new SceneEventBroker());
        }
    }
}
