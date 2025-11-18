using Game.Scripts.Gameplay.ECS.Collect.Systems;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Collect
{
  public class CollectFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ChangesAppleSystem())
        .Add(new CollectAppleSystem())
        .OneFrame<AppleChangeEvent>()
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