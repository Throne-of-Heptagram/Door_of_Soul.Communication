using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Hexagram.OperationForwardParameter;
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

namespace Door_of_Soul.Communication.HexagramCentralServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initialize(CommunicationService instance)
        {
            Instance = instance;
        }
        public bool HandleForwardOperationRequest(HexagramForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            errorMessage = "";
            switch (operationCode)
            {
                case HexagramForwardOperationCode.KnowledgeForwardOperation:
                    {
                        KnowledgeForwardOperationCode resolvedOperationCode = (KnowledgeForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.LifeForwardOperation:
                    {
                        LifeForwardOperationCode resolvedOperationCode = (LifeForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.ElementForwardOperation:
                    {
                        ElementForwardOperationCode resolvedOperationCode = (ElementForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.InfiniteForwardOperation:
                    {
                        InfiniteForwardOperationCode resolvedOperationCode = (InfiniteForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.LoveForwardOperation:
                    {
                        LoveForwardOperationCode resolvedOperationCode = (LoveForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.SpaceForwardOperation:
                    {
                        SpaceForwardOperationCode resolvedOperationCode = (SpaceForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.WillForwardOperation:
                    {
                        WillForwardOperationCode resolvedOperationCode = (WillForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.ShadowForwardOperation:
                    {
                        ShadowForwardOperationCode resolvedOperationCode = (ShadowForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.HistoryForwardOperation:
                    {
                        HistoryForwardOperationCode resolvedOperationCode = (HistoryForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.EternityForwardOperation:
                    {
                        EternityForwardOperationCode resolvedOperationCode = (EternityForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.DestinyForwardOperation:
                    {
                        DestinyForwardOperationCode resolvedOperationCode = (DestinyForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                case HexagramForwardOperationCode.ThroneForwardOperation:
                    {
                        ThroneForwardOperationCode resolvedOperationCode = (ThroneForwardOperationCode)parameters[(byte)OperationForwardParameterCode.ForwardOperationCode];
                        Dictionary<byte, object> resolvedparameters = (Dictionary<byte, object>)parameters[(byte)OperationForwardParameterCode.Parameters];
                        SendForwardOperation(resolvedOperationCode, resolvedparameters);
                        return true;
                    }
                default:
                    errorMessage = $"Unkonwn HexagramForwardOperation:{operationCode}";
                    return false;
            }
        }
        public abstract void SendForwardOperation(KnowledgeForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(LifeForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(ElementForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(InfiniteForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(LoveForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(SpaceForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(WillForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(ShadowForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(HistoryForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(EternityForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(DestinyForwardOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendForwardOperation(ThroneForwardOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}
