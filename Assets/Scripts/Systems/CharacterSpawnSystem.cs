using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace ECS_2D
{
    public partial struct CharacterSpawnSystem : ISystem
    {
        private EntityQuery _characterPrefabQuery;
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _characterPrefabQuery = SystemAPI.QueryBuilder()
                .WithAll<CharacterPrefabData>()
                .Build();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            CharacterPrefabData characterPrefab = _characterPrefabQuery.GetSingleton<CharacterPrefabData>();
            var entities = state.EntityManager.Instantiate(characterPrefab.EntityPrefab, characterPrefab.Count, Allocator.Temp);

            state.Enabled = false;
        }
    }
}