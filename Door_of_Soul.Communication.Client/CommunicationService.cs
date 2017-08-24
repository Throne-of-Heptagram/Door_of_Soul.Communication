﻿using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initial(CommunicationService instance)
        {
            Instance = instance;
        }

        public event Action<bool> OnProxyServerConnectStatusChanged;

        private bool proxyServerConnected;
        public bool ProxyServerConnected
        {
            get { return proxyServerConnected; }
            protected set
            {
                proxyServerConnected = value;
                OnProxyServerConnectStatusChanged?.Invoke(proxyServerConnected);
            }
        }

        public abstract bool IsSceneServerConnected(string sceneServerName);

        public abstract Core.External.Device GetDevice();
        public abstract bool FindAnswer(int answerId, out Core.Answer answer);
        public abstract bool FindSoul(int soulId, out Core.Soul soul);
        public abstract bool FindAvatar(int avatarId, out Core.Avatar avatar);
        public abstract bool FindWorld(int worldId, out Core.World world);
        public abstract bool FindScene(int sceneId, out Core.Scene scene);

        protected bool HandleEvent(DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceEventRouter.Instance.Route(GetDevice(), eventCode, parameters, out errorMessage);
        }

        protected bool HandleOperationResponse(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationResponseRouter.Instance.Route(GetDevice(), operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
        public abstract bool ConnectProxyServer(string serverAddress, int port, string applicationName);
        public abstract bool ConnectSceneServer(string serverAddress, int port, string applicationName);
        public abstract void Process();
        public abstract void DisconnectProxyServer();
        public abstract void DisconnectPhysicsServer();
        public abstract void SendProxyServerOperation(DeviceOperationCode operationCode, Dictionary<byte, object> parameters);
        public abstract void SendSceneServerOperation(string sceneServerName, DeviceOperationCode operationCode, Dictionary<byte, object> parameters);
    }
}