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

        public static void SystemEvent(TerminalEndPoint terminal, SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SystemEventParameterCode.EventCode, eventCode },
                { (byte)SystemEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, EndPointEventCode.SystemEvent, eventParameters);
        }
        public static void AnswerEvent(TerminalEndPoint terminal, VirtualAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerEventParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerEventParameterCode.EventCode, eventCode },
                { (byte)AnswerEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, EndPointEventCode.AnswerEvent, eventParameters);
        }
        public static void SoulEvent(TerminalEndPoint terminal, VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SoulEventParameterCode.SoulId, target.SoulId },
                { (byte)SoulEventParameterCode.EventCode, eventCode },
                { (byte)SoulEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, EndPointEventCode.SoulEvent, eventParameters);
        }
        public static void AvatarEvent(TerminalEndPoint terminal, VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarEventParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarEventParameterCode.EventCode, eventCode },
                { (byte)AvatarEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, EndPointEventCode.AvatarEvent, eventParameters);
        }
        public static void WorldEvent(TerminalEndPoint terminal, VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, EndPointEventCode.WorldEvent, eventParameters);
        }
        public static void SceneEvent(TerminalEndPoint terminal, VirtualScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SceneEventParameterCode.SceneId, target.SceneId },
                { (byte)SceneEventParameterCode.EventCode, eventCode },
                { (byte)SceneEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, EndPointEventCode.SceneEvent, eventParameters);
        }

        public static void BroadcastSystemEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void BroadcastAnswerEvent(VirtualAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void BroadcastSoulEvent(VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void BroadcastAvatarEvent(VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void BroadcastWorldEvent(VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void BroadcastSceneEvent(VirtualScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
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
