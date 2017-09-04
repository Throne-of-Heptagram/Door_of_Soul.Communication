using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public abstract class ResourceService
    {
        public static ResourceService Instance { get; private set; }
        public static void Initialize(ResourceService instance)
        {
            Instance = instance;
        }

        public abstract bool FindAnswer(int answerId, out VirtualAnswer answer);
        public abstract bool FindSoul(int soulId, out VirtualSoul soul);
        public abstract bool FindAvatar(int avatarId, out VirtualAvatar avatar);
        public abstract bool FindWorld(int worldId, out VirtualWorld world);
        public abstract bool FindScene(int sceneId, out VirtualScene scene);
    }
}
