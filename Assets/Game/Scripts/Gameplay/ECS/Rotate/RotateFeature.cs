using Game.Scripts.Gameplay.ECS.Rotate.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Rotate
{
  public class RotateFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ControlRotateSystem())
        .Add(new ChangesRotateSystem())
        .Add(new RotateSystem())
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