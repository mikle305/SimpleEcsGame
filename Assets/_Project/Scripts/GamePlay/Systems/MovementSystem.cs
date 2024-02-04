using GamePlay.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace GamePlay.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MovementData, RigidbodyData>> _filter = default;
        private readonly EcsPoolInject<MovementData> _movementDataPool = default;
        private readonly EcsPoolInject<RigidbodyData> _rigidbodyDataPool = default;
        
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter.Value)
            {
                ref var movementData = ref _movementDataPool.Value.Get(entity);
                ref var rigidbodyData = ref _rigidbodyDataPool.Value.Get(entity);
                
                rigidbodyData.Rigidbody.velocity = movementData.Direction * movementData.MoveSpeed;
            }
        }
    }
}