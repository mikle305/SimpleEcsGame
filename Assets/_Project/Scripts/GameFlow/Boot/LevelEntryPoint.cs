using System;
using GamePlay.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factories;
using VContainer;
using VContainer.Unity;

namespace GameFlow.Boot
{
    public class LevelEntryPoint : IDisposable, ITickable, IFixedTickable
    {
        private readonly PlayerFactory _playerFactory;
        private readonly IObjectResolver _objectResolver;
        
        private EcsWorld _ecsWorld;
        private IEcsSystems _tickSystems;
        private IEcsSystems _fixedTickSystems;


        public LevelEntryPoint(
            EcsWorld ecsWorld,
            IObjectResolver objectResolver,
            PlayerFactory playerFactory)
        {
            _objectResolver = objectResolver;
            _playerFactory = playerFactory;
            _ecsWorld = ecsWorld;
        }

        public void Execute()
        {
            InitEcs();
            SpawnEntities();
        }

        public void Tick()
            => _tickSystems?.Run();

        public void FixedTick()
            => _fixedTickSystems?.Run();

        public void Dispose() 
            => DisposeEcs();


        private void InitEcs()
        {
            _tickSystems = new EcsSystems(_ecsWorld);
            _tickSystems
                .Add(_objectResolver.Resolve<PlayerInputSystem>())
                .Inject()
                .Init();

            _fixedTickSystems = new EcsSystems(_ecsWorld);
            _fixedTickSystems
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Add(_objectResolver.Resolve<MovementSystem>())
                .Inject()
                .Init();
        }

        private void DisposeEcs()
        {
            if (_tickSystems != null)
            {
                _tickSystems.Destroy();
                _tickSystems = null;
            }
            
            if (_fixedTickSystems != null)
            {
                _fixedTickSystems.Destroy();
                _fixedTickSystems = null;
            }
            
            if (_ecsWorld != null)
            {
                _ecsWorld.Destroy();
                _ecsWorld = null;
            }
        }

        private void SpawnEntities()
        {
            _playerFactory.Create();
        }
    }
}