using Game.Scripts.Gameplay.ECS.Move.Components;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Tail.Systems
{
  public class TailMoveSystem : IEcsRunSystem
  {
    private EcsFilter<ForwardMoveableComponent, TailComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var details = _filter.Get2(i).Details;
        var history = _filter.Get2(i).PositionHistory;
        var detailDistance = _filter.Get2(i).DetailDistance;
        var distanceOffset = _filter.Get2(i).DistanceOffset;
        var speed = _filter.Get1(i).Speed;

        var count = details.Count;
        for (int j = 0; j < count; j++)
        {
          details[j].position = Vector3.Lerp(history[j + 1], history[j], distanceOffset / detailDistance);
          var direction = (history[j] - history[j + 1]).normalized;
          details[j].position += direction * Time.deltaTime * speed;
        }
      }
    }
  }
}