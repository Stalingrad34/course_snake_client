using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Tail.Systems
{
  public class TailWriterSystem : IEcsRunSystem
  {
    private EcsFilter<ForwardMoveableComponent, TailWriterComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var history = _filter.Get2(i).TransformHistory;
        var target = _filter.Get2(i).Target;
        var detailDistance = _filter.Get2(i).DetailDistance;
        var length = _filter.Get2(i).Length;
        var lastPoint = history[^1];

        var distance = (target.position - lastPoint.Position).magnitude;
        while (distance > detailDistance)
        {
          var direction = (target.position - lastPoint.Position).normalized;
          
          history.Add(new TransformPoint(lastPoint.Position + direction * detailDistance, target.rotation));
          if (history.Count > length + 1)
            history.RemoveAt(0);
          
          distance -= detailDistance;
        }
        
        _filter.Get2(i).DistanceOffset = distance;
      }
    }
  }
}