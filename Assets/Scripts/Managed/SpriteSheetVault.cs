using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetVault : MonoBehaviour
{
    private static Dictionary<SpriteSheetId, SpriteSheetAsset.Animations> s_idToSheet;

    public static bool IsReady { get; private set; }

    public static bool TryGetSheet(SpriteSheetId id, out SpriteSheetAsset.Animations sheet)
        => s_idToSheet.TryGetValue(id, out sheet);

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void Init()
    {
        IsReady = false;
        s_idToSheet = null;
    }
#endif

    [SerializeField] private SpriteSheetAsset[] spriteSheetAssets;

    private void Awake()
    {
        s_idToSheet = new Dictionary<SpriteSheetId, SpriteSheetAsset.Animations>();
        
        var assets = spriteSheetAssets.AsSpan();

        foreach (var asset in assets)
        {
            var assetId = asset.AssetID;
            var assetName = asset.AssetName;
            var animations = asset.AnimationList.Span;
        
            foreach (var anim in animations)
            {
                var animID = anim.AnimID;
                var animName = anim.AnimName;
                var directions = anim.DirectionList.Span;
        
                var id = new SpriteSheetId(assetId, animID);
                s_idToSheet.TryAdd(id, anim);
            }
        }

        IsReady = true;
    }
}