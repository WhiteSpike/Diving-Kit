using CustomItemBehaviourLibrary.AbstractItems;

namespace DivingKit.Behaviour
{
    /// <summary>
    /// <para>Item which allows players holding the item to breath underwater, however their vision will be blocked by the model as it will be placed on their head.</para>
    /// </summary>
    internal class DivingKitBehaviour : UnderwaterBreatherBehaviour
    {
        internal const string ITEM_NAME = "Diving Kit";

        protected bool KeepScanNode
        {
            get
            {
                return Plugin.Config.SCAN_NODE;
            }
        }

        public override void Start()
        {
            base.Start();
            if (!KeepScanNode) Destroy(gameObject.GetComponentInChildren<ScanNodeProperties>());
        }
    }
}
