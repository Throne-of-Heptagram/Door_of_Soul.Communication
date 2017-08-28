using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    public static class EndPointEventApi
    {
        public static void SendEvent(TerminalEndPoint target, EndPointEventCode eventCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendEvent(target, eventCode, parameters);
        }
        public static void SystemEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SystemEventParameterCode.EventCode, eventCode },
                { (byte)SystemEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in CommunicationService.Instance.AllEndPoints)
            {
                SendEvent(endPoint, EndPointEventCode.SystemEvent, eventParameters);
            }
        }
        public static void AnswerEvent(Core.Answer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerEventParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerEventParameterCode.EventCode, eventCode },
                { (byte)AnswerEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in CommunicationService.Instance.AllProxyEndPoints)
            {
                SendEvent(endPoint, EndPointEventCode.AnswerEvent, eventParameters);
            }
        }
        public static void SoulEvent(Core.Soul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SoulEventParameterCode.SoulId, target.SoulId },
                { (byte)SoulEventParameterCode.EventCode, eventCode },
                { (byte)SoulEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in CommunicationService.Instance.AllProxyEndPoints)
            {
                SendEvent(endPoint, EndPointEventCode.SoulEvent, eventParameters);
            }
        }
        public static void AvatarEvent(Core.Avatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarEventParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarEventParameterCode.EventCode, eventCode },
                { (byte)AvatarEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in CommunicationService.Instance.AllProxyEndPoints)
            {
                SendEvent(endPoint, EndPointEventCode.AvatarEvent, eventParameters);
            }
        }
        public static void WorldEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in CommunicationService.Instance.AllSceneEndPoints)
            {
                SendEvent(endPoint, EndPointEventCode.WorldEvent, eventParameters);
            }
        }
        public static void SceneEvent(Core.Scene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SceneEventParameterCode.SceneId, target.SceneId },
                { (byte)SceneEventParameterCode.EventCode, eventCode },
                { (byte)SceneEventParameterCode.Parameters, parameters }
            };
            foreach (var endPoint in CommunicationService.Instance.AllSceneEndPoints)
            {
                SendEvent(endPoint, EndPointEventCode.SceneEvent, eventParameters);
            }
        }
    }
}
