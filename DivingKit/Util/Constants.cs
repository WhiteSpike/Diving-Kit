using DivingKit.Behaviour;
namespace DivingKit.Misc.Util
{
    internal static class Constants
    {
        internal const string ITEM_SCAN_NODE_KEY_FORMAT = "Enable scan node of {0}";
        internal const bool ITEM_SCAN_NODE_DEFAULT = true;
        internal const string ITEM_SCAN_NODE_DESCRIPTION = "Shows a scan node on the item when scanning";

        #region Diving Kit

        internal const string DIVING_KIT_PRICE_KEY = $"{DivingKitBehaviour.ITEM_NAME} price";
        internal const int DIVING_KIT_PRICE_DEFAULT = 650;
        internal const string DIVING_KIT_PRICE_DESCRIPTION = $"Price for {DivingKitBehaviour.ITEM_NAME}.";

        internal const string DIVING_KIT_WEIGHT_KEY = "Item weight";
        internal const int DIVING_KIT_WEIGHT_DEFAULT = 65;
        internal const string DIVING_KIT_WEIGHT_DESCRIPTION = "Weight (in lbs)";

        internal const string DIVING_KIT_TWO_HANDED_KEY = "Two Handed Item";
        internal const bool DIVING_KIT_TWO_HANDED_DEFAULT = true;
        internal const string DIVING_KIT_TWO_HANDED_DESCRIPTION = "One or two handed item.";

        internal const string DIVING_KIT_CONDUCTIVE_KEY = "Conductive";
        internal const bool DIVING_KIT_CONDUCTIVE_DEFAULT = true;
        internal const string DIVING_KIT_CONDUCTIVE_DESCRIPTION = "Wether it attracts lightning to the item or not. (Or other mechanics that rely on item being conductive)";

        internal const string DIVING_KIT_DROP_AHEAD_PLAYER_KEY = "Drop ahead of player when dropping";
        internal const bool DIVING_KIT_DROP_AHEAD_PLAYER_DEFAULT = false;
        internal const string DIVING_KIT_DROP_AHEAD_PLAYER_DESCRIPTION = "If on, the item will drop infront of the player. Otherwise, drops underneath them and slightly infront.";

        internal const string DIVING_KIT_GRABBED_BEFORE_START_KEY = "Grabbable before game start";
        internal const bool DIVING_KIT_GRABBED_BEFORE_START_DEFAULT = false;
        internal const string DIVING_KIT_GRABBED_BEFORE_START_DESCRIPTION = "Allows wether the item can be grabbed before hand or not";

        internal const string DIVING_KIT_HIGHEST_SALE_PERCENTAGE_KEY = "Highest Sale Percentage";
        internal const int DIVING_KIT_HIGHEST_SALE_PERCENTAGE_DEFAULT = 50;
        internal const string DIVING_KIT_HIGHEST_SALE_PERCENTAGE_DESCRIPTION = "Maximum percentage of sale allowed when this item is selected for a sale.";

        internal static readonly string DIVING_KIT_SCAN_NODE_KEY = string.Format(ITEM_SCAN_NODE_KEY_FORMAT, DivingKitBehaviour.ITEM_NAME);
        #endregion
    }
}
