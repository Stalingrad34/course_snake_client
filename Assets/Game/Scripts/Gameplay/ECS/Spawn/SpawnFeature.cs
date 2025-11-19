using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Gameplay.ECS.Spawn.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn
{
  public class SpawnFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private Camera _mainCamera;
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ChangesSpawnPartSystem())
        .Add(new SpawnSnakeHeadSystem())
        .Add(new SpawnSnakePartSystem())
        .Add(new SpawnAppleSystem())
        .OneFrame<SpawnSnakeHeadEvent>()
        .OneFrame<SpawnSnakePartEvent>()
        .OneFrame<SpawnAppleEvent>()
        .Inject(_mainCamera)
        .Init();
    }

    public void Run()
    {
      _systems?.Run();
    }

    public void Destroy()
    {
      _systems?.Destroy();
    }
  }
}