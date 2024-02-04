﻿using GameFlow.Boot;
using GamePlay.Systems;
using Leopotam.EcsLite;
using Services.Factories;
using VContainer;
using VContainer.Unity;

namespace GameFlow.Scopes
{
    public class LevelScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterEntryPoint(builder);
            RegisterEcsWorld(builder);
            RegisterEcsSystems(builder);
            RegisterEntitiesFactories(builder);
        }

        private static void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelEntryPoint>().AsSelf();
            builder.RegisterBuildCallback(r => r.Resolve<LevelEntryPoint>().Execute());
        }

        private static void RegisterEcsWorld(IContainerBuilder builder)
            => builder.RegisterInstance(new EcsWorld());

        private static void RegisterEcsSystems(IContainerBuilder builder)
        {
            builder.Register<MovementSystem>(Lifetime.Singleton);
            builder.Register<PlayerInputSystem>(Lifetime.Singleton);
        }

        private static void RegisterEntitiesFactories(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Singleton);
        }
    }
}