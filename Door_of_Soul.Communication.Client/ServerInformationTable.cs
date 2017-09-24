using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client
{
    public class ServerInformationTable
    {
        public static ServerInformationTable Instance { get; private set; } = new ServerInformationTable();

        private Dictionary<string, Tuple<string, int>> serverAddressInformationTable = new Dictionary<string, Tuple<string, int>>();
        private Dictionary<int, string> avatarIdApplicationNameTable = new Dictionary<int, string>();
        private Dictionary<int, string> worldIdApplicationNameTable = new Dictionary<int, string>();
        private Dictionary<int, string> sceneIdApplicationNameTable = new Dictionary<int, string>();
        public string DefaultTrinityServerApplicationName { get; set; }
        public string LoginServerApplicationName { get; set; }

        public void UpdateServerAddressInformation(string applicationName, string serverAddress, int port)
        {
            if(serverAddressInformationTable.ContainsKey(applicationName))
            {
                serverAddressInformationTable[applicationName] = new Tuple<string, int>(serverAddress, port);
            }
            else
            {
                serverAddressInformationTable.Add(applicationName, new Tuple<string, int>(serverAddress, port));
            }
        }

        public void UpdateAvatarIdApplicationNameTable(int avatarId, string applicationName)
        {
            if (avatarIdApplicationNameTable.ContainsKey(avatarId))
            {
                avatarIdApplicationNameTable[avatarId] = applicationName;
            }
            else
            {
                avatarIdApplicationNameTable.Add(avatarId, applicationName);
            }
        }
        public void UpdateWorldIdApplicationNameTable(int worldId, string applicationName)
        {
            if (worldIdApplicationNameTable.ContainsKey(worldId))
            {
                worldIdApplicationNameTable[worldId] = applicationName;
            }
            else
            {
                worldIdApplicationNameTable.Add(worldId, applicationName);
            }
        }
        public void UpdateSceneIdApplicationNameTable(int sceneId, string applicationName)
        {
            if (sceneIdApplicationNameTable.ContainsKey(sceneId))
            {
                sceneIdApplicationNameTable[sceneId] = applicationName;
            }
            else
            {
                sceneIdApplicationNameTable.Add(sceneId, applicationName);
            }
        }

        public bool FindApplicationNameByAvatarId(int avatarId, out string applicationName)
        {
            if(avatarIdApplicationNameTable.ContainsKey(avatarId))
            {
                applicationName = avatarIdApplicationNameTable[avatarId];
                return true;
            }
            else
            {
                applicationName = "";
                return false;
            }
        }
        public bool FindApplicationNameByWorldId(int worldId, out string applicationName)
        {
            if (worldIdApplicationNameTable.ContainsKey(worldId))
            {
                applicationName = worldIdApplicationNameTable[worldId];
                return true;
            }
            else
            {
                applicationName = "";
                return false;
            }
        }
        public bool FindApplicationNameBySceneId(int sceneId, out string applicationName)
        {
            if (sceneIdApplicationNameTable.ContainsKey(sceneId))
            {
                applicationName = avatarIdApplicationNameTable[sceneId];
                return true;
            }
            else
            {
                applicationName = "";
                return false;
            }
        }
    }
}
