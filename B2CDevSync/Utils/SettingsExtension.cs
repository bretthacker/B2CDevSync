using B2CDevSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2CDevSync.Properties
{
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        public Settings()
        {
            SyncProfiles = new SyncProfiles();
        }
        [global::System.Configuration.UserScopedSetting()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        
        public SyncProfiles SyncProfiles
        {
            get
            {
                return ((SyncProfiles)(this["SyncProfiles"]));
            }
            set
            {
                this["SyncProfiles"] = value;
            }
        }
    }
}