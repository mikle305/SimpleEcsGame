using GamePlay.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace GamePlay.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MovementData, ComponentRef<Rigidbody2D>>> _filter = default;
        private readonly EcsPoolInject<MovementData> _movementDataPool = default;
        private readonly EcsPoolInject<ComponentRef<Rigidbody2D>> _rigidbodyRefPool = default;
        
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter.Value)
            {
                ref var movementData = ref _movementDataPool.Value.Get(entity);
                var rigidbody = _rigidbodyRefPool.Value.Get(entity).Value;
                
                rigidbody.velocity = movementData.Direction * movementData.MoveSpeed;
            }
        }
    }
}