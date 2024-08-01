using BepInEx;
using BepInEx.Logging;
using DivingKit.Behaviour;
using DivingKit.Misc;
using HarmonyLib;
using LethalLib.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
namespace DivingKit
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.sigurd.csync")]
    [BepInDependency("evaisa.lethallib")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);

        public new static PluginConfig Config;
        internal static GameObject networkPrefab;

        void Awake()
        {
            Config = new PluginConfig(base.Config);

            // netcode patching stuff
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "divingkit");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            string root = "Assets/Diving Kit/";

            Item divingKitItem = ScriptableObject.CreateInstance<Item>();
            divingKitItem.name = "DivingKitItemProperties";
            divingKitItem.allowDroppingAheadOfPlayer = Config.DROP_AHEAD_PLAYER;
            divingKitItem.canBeGrabbedBeforeGameStart = Config.GRABBED_BEFORE_START;
            divingKitItem.canBeInspected = false;
            divingKitItem.creditsWorth = Config.PRICE;
            divingKitItem.restingRotation = new Vector3(0f, 0f, 0f);
            divingKitItem.rotationOffset = new Vector3(0, 20f, -90f);
            divingKitItem.positionOffset = new Vector3(-0.1f, -0.5f, -0.3f);
            divingKitItem.weight = 1f + (Config.WEIGHT / 100f);
            divingKitItem.twoHanded = Config.TWO_HANDED;
            divingKitItem.itemIcon = bundle.LoadAsset<Sprite>(root + "Icon.png");
            divingKitItem.spawnPrefab = bundle.LoadAsset<GameObject>(root + "DivingKit.prefab");
            divingKitItem.dropSFX = bundle.LoadAsset<AudioClip>(root + "Drop.ogg");
            divingKitItem.grabSFX = bundle.LoadAsset<AudioClip>(root + "Grab.ogg");
            divingKitItem.pocketSFX = bundle.LoadAsset<AudioClip>(root + "Pocket.ogg");
            divingKitItem.throwSFX = bundle.LoadAsset<AudioClip>(root + "Throw.ogg");
            divingKitItem.highestSalePercentage = Config.HIGHEST_SALE_PERCENTAGE;
            divingKitItem.itemName = DivingKitBehaviour.ITEM_NAME;
            divingKitItem.itemSpawnsOnGround = true;
            divingKitItem.isConductiveMetal = Config.CONDUCTIVE;
            divingKitItem.requiresBattery = false;
            divingKitItem.batteryUsage = 0f;

            DivingKitBehaviour grabbableObject = divingKitItem.spawnPrefab.AddComponent<DivingKitBehaviour>();
            grabbableObject.itemProperties = divingKitItem;
            grabbableObject.grabbable = true;
            grabbableObject.grabbableToEnemies = true;
            NetworkPrefabs.RegisterNetworkPrefab(divingKitItem.spawnPrefab);

            TerminalNode infoNode = SetupInfoNode();
            Items.RegisterShopItem(shopItem: divingKitItem, itemInfo: infoNode, price: divingKitItem.creditsWorth);

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
        internal static TerminalNode SetupInfoNode()
        {
            TerminalNode infoNode = ScriptableObject.CreateInstance<TerminalNode>();
            infoNode.displayText += GetDisplayInfo() + "\n";
            infoNode.clearPreviousText = true;
            return infoNode;
        }
        public static string GetDisplayInfo()
        {
            string hands = Config.TWO_HANDED.Value ? "two" : "one";
            return $"DIVING KIT - ${Config.PRICE.Value}\n\n" +
                "Breath underwater.\n" +
                $"Weights {Mathf.RoundToInt((Config.WEIGHT.Value - 1) * 100)} lbs and is {hands} handed.";
        }
    }   
}
