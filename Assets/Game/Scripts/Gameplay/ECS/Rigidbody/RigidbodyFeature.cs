using Game.Scripts.Gameplay.ECS.Rigidbody.Components;
using Game.Scripts.Gameplay.ECS.Rigidbody.Systems;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Rigidbody
{
  public class RigidbodyFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    public void Init()
    {
      _systems = new EcsSystems(_world);
      _systems
        .Add(new ControlMoveVelocitySystem())
        .Add(new MoveVelocitySystem())
        .Add(new AngularVelocitySystem())
        .Add(new ForceSystem())
        .OneFrame<AddForceEvent>()
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