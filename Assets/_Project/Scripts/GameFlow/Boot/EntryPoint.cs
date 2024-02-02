using System;
using GamePlay.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factories;
using VContainer.Unity;

namespace GameFlow.Boot
{
    public sealed class EntryPoint : IDisposable, ITickable, IFixedTickable
    {
        private EcsWorld _world;
        private IEcsSystems _tickSystems;
        private IEcsSystems _fixedTickSystems;
        private readonly ObjectActivator _objectActivator;


        public EntryPoint(ObjectActivator objectActivator)
        {
            _objectActivator = objectActivator;
        }

        public void Execute()
        {
            InitWorld();
            InitTickSystems();
            InitFixedTickSystems();
        }

        public void Tick() 
            => _tickSystems?.Run();

        public void FixedTick()
            => _fixedTickSystems?.Run();

        public void Dispose()
        {
            DisposeTickSystems();
            DisposeFixedTickSystems();
            DisposeWorld();
        }
        
        private void InitTickSystems()
        {
            _tickSystems = new EcsSystems(_world);
            _tickSystems
                .Add(_objectActivator.Resolve<GameInitSystem>())
                .Inject()
                .Init();
        }

        private void InitFixedTickSystems()
        {
            _fixedTickSystems = new EcsSystems(_world);
            _fixedTickSystems
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Inject()
                .Init();
        }

        private void InitWorld() 
            => _world = new EcsWorld();

        private void DisposeWorld()
        {
            if (_world == null) 
                return;
            
            _world.Destroy();
            _world = null;
        }

        private void DisposeFixedTickSystems()
        {
            if (_fixedTickSystems == null) 
                return;
            
            _fixedTickSystems.Destroy();
            _fixedTickSystems = null;
        }

        private void DisposeTickSystems()
        {
            if (_tickSystems == null) 
                return;
            
            _tickSystems.Destroy();
            _tickSystems = null;
        }
    }
}