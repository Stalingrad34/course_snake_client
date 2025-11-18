using Game.Scripts.Gameplay.ECS.Collision.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Collision.Systems
{
  public class SphereCollisionSystem : IEcsRunSystem
  {
    private EcsFilter<SphereCollisionComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var position = _filter.Get1(i).Target.position;
        var radius = _filter.Get1(i).Radius;
        var collisions = new Collider[4];
        
        var colliders = Physics.OverlapSphereNonAlloc(position, radius, collisions);
        if (colliders == 0)
          continue;

        foreach (var collision in collisions)
        {
          if (collision == null)
            continue;
          
          if (!collision.TryGetComponent<ConvertToEntity>(out var convert)) 
            continue;
          
          var entity = convert.TryGetEntity();
          entity?.Get<CollisionEvent>();
        }
      }
    }
  }
}