using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSheetAsset", menuName = "New Asset/SpriteSheetAsset")]
public class SpriteSheetAsset : ScriptableObject
{
    [SerializeField] private ushort assetId;
    [SerializeField] private string assetName;
    [SerializeField] private Animations[] animationList;

    public string AssetName => assetName;

    public ushort AssetID => assetId;

    public ReadOnlyMemory<Animations> AnimationList => animationList;

    [Serializable]
    public class Animations
    {
        [SerializeField] private ushort animId;
        [SerializeField] private string animName;
        [SerializeField] private Directions[] directionList;

        public string AnimName => animName;

        public ushort AnimID => animId;

        public ReadOnlyMemory<Directions> DirectionList => directionList;

        [Serializable]
        public class Directions
        {
            [SerializeField] private ushort directionId;
            [SerializeField] private Sprite[] spriteList;
            
            public ushort DirectionID => directionId;
            
            public ReadOnlyMemory<Sprite> SpriteList => spriteList;
        }
    }
}