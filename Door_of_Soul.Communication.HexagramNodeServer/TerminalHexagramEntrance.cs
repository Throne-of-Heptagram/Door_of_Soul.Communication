using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class TerminalHexagramEntrance
    {
        public delegate void SendEventDelegate(DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public int HexagramEntranceId { get; private set; }
    }
}
