using Game.Scripts.Gameplay.ECS.Move.Components;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Tail.Systems
{
  public class TailHistorySystem : IEcsRunSystem
  {
    private EcsFilter<ForwardMoveableComponent, TailComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var target = _filter.Get2(i).Target;
        var history = _filter.Get2(i).PositionHistory;
        var detailDistance = _filter.Get2(i).DetailDistance;

        var distance = (target.position - history[0]).magnitude;
        while (distance > detailDistance)
        {
          var direction = (target.position - history[0]).normalized;
          
          history.Insert(0, history[0] + direction * detailDistance);
          history.RemoveAt(history.Count - 1);
          
          distance -=  detailDistance;
        }
        
        _filter.Get2(i).DistanceOffset = distance;
      }
    }
  }
}