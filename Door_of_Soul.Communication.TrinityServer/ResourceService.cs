using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer
{
    public abstract class ResourceService
    {
        public static ResourceService Instance { get; private set; }
        public static void Initialize(ResourceService instance)
        {
            Instance = instance;
        }

        public abstract bool FindAnswer(int answerId, out TerminalAnswer answer);
        public abstract bool FindSoul(int soulId, out VirtualSoul soul);
        public abstract bool FindAvatar(int avatarId, out VirtualAvatar avatar);
    }
}
