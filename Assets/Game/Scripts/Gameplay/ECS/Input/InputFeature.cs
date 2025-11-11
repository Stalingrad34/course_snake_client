using Game.Scripts.Gameplay.ECS.Input.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Input
{
  public class InputFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;
    private Camera _camera;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new MouseSystem())
        .Add(new DebugMouseSystem())
        .Inject(_camera)
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