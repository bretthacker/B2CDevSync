using B2CDevSync.Models;
using System;
using System.Collections.Generic;

namespace B2CDevSync.Models
{
    [Serializable]
    public class SyncProfiles
    {
        public List<SyncProfile> Profiles { get; set; }
        public SyncProfiles()
        {
            Profiles = new List<SyncProfile>();
        }
    }

    [Serializable]
    public class SyncProfile
    {
        public string SyncProfileName { get; set; }
        public string StorageConnectionString { get; set; }
        public string StorageContainerName { get; set; }
        public bool SyncStorageBool { get; set; }
        public bool SyncPolicyBool { get; set; }
        public string UIPath { get; set; }
        public bool SyncRecursive { get; set; }
        public string PolicyPath { get; set; }

        public SyncProfile()
        {
            SyncStorageBool = true;
            SyncPolicyBool = true;
            SyncRecursive = true;
        }
    }
}

