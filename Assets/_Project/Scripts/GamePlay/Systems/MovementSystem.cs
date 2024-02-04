using GamePlay.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace GamePlay.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MovementData>> _filter;
        private readonly EcsPoolInject<MovementData> _movementDataPool;
        private readonly EcsPoolInject<ComponentRef<Rigidbody2D>> _rigidbodyRefPool;
        private readonly EcsPoolInject<ComponentRef<Transform>> _transformRefPool;
        
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter.Value)
            {
                ref var movementData = ref _movementDataPool.Value.Get(entity);
                MoveEntity(entity, movementData);
                RotateEntitySmoothly(entity, movementData);
            }
        }

        private void MoveEntity(int entity, MovementData movementData)
        {
            var rigidbody = _rigidbodyRefPool.Value.Get(entity).Value;
            rigidbody.velocity = movementData.Direction * movementData.MoveSpeed;
        }

        private void RotateEntitySmoothly(int entity, MovementData movementData)
        {
            var direction = movementData.Direction;
            if (direction == Vector2.zero)
                return;
    
            var transform = _transformRefPool.Value.Get(entity).Value;
    
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(0, 0, angle - 90);
    
            float step = movementData.RotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
        }
    }
}