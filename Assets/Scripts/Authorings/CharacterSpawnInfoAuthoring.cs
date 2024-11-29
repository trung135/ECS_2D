using Unity.Entities;
using UnityEngine;

public class CharacterSpawnInfoAuthoring : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private int count;
    private class CharacterSpawnInfoAuthoringBaker : Baker<CharacterSpawnInfoAuthoring>
    {
        public override void Bake(CharacterSpawnInfoAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new CharacterPrefabData
            {
                EntityPrefab = GetEntity(authoring.characterPrefab, TransformUsageFlags.Dynamic),
                Count = authoring.count
            });
        }
    }
}