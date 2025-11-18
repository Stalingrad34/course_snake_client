using Game.Scripts.Gameplay.ECS.Collect.Components;
using Game.Scripts.Gameplay.ECS.Collision.Components;
using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Collect.Systems
{
  public class CollectAppleSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, CollectAppleComponent, CollisionEvent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        _filter.Get1(i).Transform.gameObject.SetActive(false);
        MultiplayerManager.Instance.CollectApple(_filter.Get2(i).Id);
      }
    }
  }
}