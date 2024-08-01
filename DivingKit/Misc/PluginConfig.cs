using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using DivingKit.Behaviour;
using DivingKit.Misc.Util;
using System.Runtime.Serialization;

namespace DivingKit.Misc
{
    [DataContract]
    public class PluginConfig : SyncedConfig2<PluginConfig>
    {
        [field: SyncedEntryField] public SyncedEntry<bool> SCAN_NODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> WEIGHT { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> TWO_HANDED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> DROP_AHEAD_PLAYER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> GRABBED_BEFORE_START { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> CONDUCTIVE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> HIGHEST_SALE_PERCENTAGE { get; set; }
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            string topSection = DivingKitBehaviour.ITEM_NAME;

            PRICE = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_PRICE_KEY, Constants.DIVING_KIT_PRICE_DEFAULT, Constants.DIVING_KIT_PRICE_DESCRIPTION);
            WEIGHT = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_WEIGHT_KEY, Constants.DIVING_KIT_WEIGHT_DEFAULT, Constants.DIVING_KIT_WEIGHT_DESCRIPTION);
            TWO_HANDED = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_TWO_HANDED_KEY, Constants.DIVING_KIT_TWO_HANDED_DEFAULT, Constants.DIVING_KIT_TWO_HANDED_DESCRIPTION);
            SCAN_NODE = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_SCAN_NODE_KEY, Constants.ITEM_SCAN_NODE_DEFAULT, Constants.ITEM_SCAN_NODE_DESCRIPTION);
            DROP_AHEAD_PLAYER = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_DROP_AHEAD_PLAYER_KEY, Constants.DIVING_KIT_DROP_AHEAD_PLAYER_DEFAULT, Constants.DIVING_KIT_DROP_AHEAD_PLAYER_DESCRIPTION);
            CONDUCTIVE = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_CONDUCTIVE_KEY, Constants.DIVING_KIT_CONDUCTIVE_DEFAULT, Constants.DIVING_KIT_CONDUCTIVE_DESCRIPTION);
            GRABBED_BEFORE_START = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_GRABBED_BEFORE_START_KEY, Constants.DIVING_KIT_GRABBED_BEFORE_START_DEFAULT, Constants.DIVING_KIT_GRABBED_BEFORE_START_DESCRIPTION);
            HIGHEST_SALE_PERCENTAGE = cfg.BindSyncedEntry(topSection, Constants.DIVING_KIT_HIGHEST_SALE_PERCENTAGE_KEY, Constants.DIVING_KIT_HIGHEST_SALE_PERCENTAGE_DEFAULT, Constants.DIVING_KIT_HIGHEST_SALE_PERCENTAGE_DESCRIPTION);

            ConfigManager.Register(this);
        }
    }
}
