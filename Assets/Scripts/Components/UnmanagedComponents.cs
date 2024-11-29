using Unity.Entities;
using Unity.Mathematics;

public struct InputData : IComponentData
{
    public float2 Value;
}

public struct SpeedData : IComponentData
{
    public int Value;
}

public struct CharacterPrefabData : IComponentData
{
    public Entity EntityPrefab;
    public int Count;
}