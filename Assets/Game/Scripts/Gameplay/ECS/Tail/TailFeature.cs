using Game.Scripts.Gameplay.ECS.Tail.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Tail
{
  public class TailFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new TailLengthSystem())
        .Add(new TailWriterSystem())
        .Add(new TailReaderSystem())
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