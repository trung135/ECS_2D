using Unity.Entities;
using UnityEngine;

namespace ECS_2D
{
    public sealed partial class InputSystem : SystemBase
    {
        private InputManager _inputManager;
        
        protected override void OnCreate()
        {
            RequireForUpdate<InputData>();
            _inputManager = new InputManager();
            _inputManager.Enable();
        }
        
        protected override void OnUpdate()
        {
            foreach (var inputData in SystemAPI.Query<RefRW<InputData>>())
            {
                inputData.ValueRW.Value = _inputManager.Character.Move.ReadValue<Vector2>();
            }
        }
        
        protected override void OnDestroy()
        {
            _inputManager.Disable();
        }
    }
}