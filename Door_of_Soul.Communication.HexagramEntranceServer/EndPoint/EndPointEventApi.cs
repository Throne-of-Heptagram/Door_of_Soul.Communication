using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    public static class EndPointEventApi
    {
        public static void SendEvent(TerminalEndPoint target, EndPointEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
        public static void SystemEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SystemEventParameterCode.EventCode, eventCode },
                { (byte)SystemEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in EndPointFactory.Instance.Subjects)
            {
                SendEvent(endPoint, EndPointEventCode.SystemEvent, eventParameters);
            }
        }
        public static void AnswerEvent(VirtualAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerEventParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerEventParameterCode.EventCode, eventCode },
                { (byte)AnswerEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in EndPointFactory.Instance.Subjects.Where(x => x.EndPointType == EndPointType.ProxyServer))
            {
                SendEvent(endPoint, EndPointEventCode.AnswerEvent, eventParameters);
            }
        }
        public static void SoulEvent(VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SoulEventParameterCode.SoulId, target.SoulId },
                { (byte)SoulEventParameterCode.EventCode, eventCode },
                { (byte)SoulEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in EndPointFactory.Instance.Subjects.Where(x => x.EndPointType == EndPointType.ProxyServer))
            {
                SendEvent(endPoint, EndPointEventCode.SoulEvent, eventParameters);
            }
        }
        public static void AvatarEvent(VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarEventParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarEventParameterCode.EventCode, eventCode },
                { (byte)AvatarEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in EndPointFactory.Instance.Subjects.Where(x => x.EndPointType == EndPointType.ProxyServer))
            {
                SendEvent(endPoint, EndPointEventCode.AvatarEvent, eventParameters);
            }
        }
        public static void WorldEvent(VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in EndPointFactory.Instance.Subjects.Where(x => x.EndPointType == EndPointType.SceneServer))
            {
                SendEvent(endPoint, EndPointEventCode.WorldEvent, eventParameters);
            }
        }
        public static void SceneEvent(VirtualScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SceneEventParameterCode.SceneId, target.SceneId },
                { (byte)SceneEventParameterCode.EventCode, eventCode },
                { (byte)SceneEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in EndPointFactory.Instance.Subjects.Where(x => x.EndPointType == EndPointType.SceneServer))
            {
                SendEvent(endPoint, EndPointEventCode.SceneEvent, eventParameters);
            }
        }
    }
}
