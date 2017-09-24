using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using Door_of_Soul.Communication.Protocol.Hexagram.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.HexagramCentral.OperationForwardParameter;
using Door_of_Soul.Communication.Protocol.Hexagram.History;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public static class HexagramOperationRequestApi
    {
        public static void SendOperationRequest(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CentralCommunicationService.Instance.SendForwardOperation(operationCode, parameters);
        }
        
        public static void KnowledgeOperationRequest(KnowledgeForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.KnowledgeForwardOperation, operationRequestParameters);
        }
        public static void LifeOperationRequest(LifeForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.LifeForwardOperation, operationRequestParameters);
        }
        public static void ElementOperationRequest(ElementForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.ElementForwardOperation, operationRequestParameters);
        }
        public static void InfiniteOperationRequest(InfiniteForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.InfiniteForwardOperation, operationRequestParameters);
        }
        public static void LoveOperationRequest(LoveForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.LoveForwardOperation, operationRequestParameters);
        }
        public static void SpaceOperationRequest(SpaceForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.SpaceForwardOperation, operationRequestParameters);
        }
        public static void WillOperationRequest(WillForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.WillForwardOperation, operationRequestParameters);
        }
        public static void ShadowOperationRequest(ShadowForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.ShadowForwardOperation, operationRequestParameters);
        }
        public static void HistoryOperationRequest(HistoryForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.HistoryForwardOperation, operationRequestParameters);
        }
        public static void EternityOperationRequest(EternityForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.EternityForwardOperation, operationRequestParameters);
        }
        public static void DestinyOperationRequest(DestinyForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.DestinyForwardOperation, operationRequestParameters);
        }
        public static void ThroneOperationRequest(ThroneForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)OperationForwardParameterCode.ForwardOperationCode, operationCode },
                { (byte)OperationForwardParameterCode.Parameters, parameters }
            };
            SendOperationRequest(HexagramForwardOperationCode.ThroneForwardOperation, operationRequestParameters);
        }
    }
}
