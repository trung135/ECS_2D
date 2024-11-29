using Unity.Entities;
using UnityEngine;

class CharacterPrefabAuthoring : MonoBehaviour
{
    class CharacterPrefabAuthoringBaker : Baker<CharacterPrefabAuthoring>
    {
        public override void Bake(CharacterPrefabAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<InputData>(entity);
            AddComponent(entity, new SpeedData { Value = 10 });
        }
    }
}
