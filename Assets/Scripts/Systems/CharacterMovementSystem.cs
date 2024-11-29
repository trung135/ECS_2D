using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace ECS_2D
{
    public partial struct CharacterMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            EntityQuery query = SystemAPI.QueryBuilder()
                .WithAll<InputData>()
                .WithAll<SpeedData>()
                .WithAllRW<LocalTransform>()
                .Build();
            state.RequireForUpdate(query);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, speed, input) in 
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<SpeedData>, RefRO<InputData>>())
            {
                transform.ValueRW.Position.x += speed.ValueRO.Value * input.ValueRO.Value.x * SystemAPI.Time.DeltaTime;
                transform.ValueRW.Position.y += speed.ValueRO.Value * input.ValueRO.Value.y * SystemAPI.Time.DeltaTime;
            }
        }
    }
}