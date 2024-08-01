using GameNetcodeStuff;
using UnityEngine;

namespace DivingKit.Behaviour
{
    /// <summary>
    /// <para>Item which allows players holding the item to breath underwater, however their vision will be blocked by the model as it will be placed on their head.</para>
    /// </summary>
    internal class DivingKitBehaviour : GrabbableObject
    {
        internal const string ITEM_NAME = "Diving Kit";
        /// <summary>
        /// Local player of Network Manager
        /// </summary>
        private PlayerControllerB localPlayer;
        /// <summary>
        /// Instance which controls the drowning timer of the player
        /// </summary>
        private StartOfRound roundInstance;

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
            localPlayer = GameNetworkManager.Instance.localPlayerController;
            roundInstance = StartOfRound.Instance;
        }
        /// <summary>
        /// Check if this item is currently grabbed by a player and if it's the local player and if so, reset their drown timer.
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (isHeld && playerHeldBy == localPlayer)
            {
                roundInstance.drowningTimer = 1f;
            }
        }
    }
}
