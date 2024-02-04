﻿using System;
using GamePlay.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using VContainer;

namespace GameFlow.Boot
{
    public class EcsLoop : IDisposable
    {
        private readonly IObjectResolver _objectResolver;
        
        private EcsWorld _ecsWorld;
        private IEcsSystems _tickSystems;
        private IEcsSystems _fixedTickSystems;


        public EcsLoop(EcsWorld ecsWorld, IObjectResolver objectResolver)
        {
            _ecsWorld = ecsWorld;
            _objectResolver = objectResolver;
        }

        public void Init()
            => InitSystems();

        public void Tick() 
            => _tickSystems?.Run();

        public void FixedTick()
            => _fixedTickSystems?.Run();

        public void Dispose()
            => DisposeWorld();
        
        
        private void InitSystems()
        {
            _tickSystems = new EcsSystems(_ecsWorld);
            _fixedTickSystems = new EcsSystems(_ecsWorld);
            
            _tickSystems
                .Add(_objectResolver.Resolve<PlayerInputSystem>())
                .Inject()
                .Init();

            _fixedTickSystems
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Add(_objectResolver.Resolve<MovementSystem>())
                .Inject()
                .Init();
        }

        private void DisposeWorld()
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
    }
}