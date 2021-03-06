﻿using Door_of_Soul.Core.ObserverServer;

namespace Door_of_Soul.Communication.ObserverServer
{
    public abstract class ResourceService
    {
        public static ResourceService Instance { get; private set; }
        public static void Initialize(ResourceService instance)
        {
            Instance = instance;
        }

        public abstract bool FindWorld(int worldId, out VirtualWorld world);
        public abstract bool FindScene(int sceneId, out TerminalScene scene);
    }
}
