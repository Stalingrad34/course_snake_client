using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Tail.Systems
{
  public class TailReaderSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, TailReaderComponent> _readers;
    private EcsFilter<IdentifierComponent, TailWriterComponent> _writers;

    public void Run()
    {
      foreach (var i in _readers)
      {
        if (!_readers.Get2(i).TailIdx.HasValue)
          continue;
       
        var tailIdx = _readers.Get2(i).TailIdx.Value;
        var writerId = _readers.Get2(i).TailWriterId;
        
        foreach (var ii in _writers)
        {
          if (!_writers.Get1(ii).Id.Equals(writerId))
            continue;
          
          var history = _writers.Get2(ii).TransformHistory;
          if (history.Count - 1 < tailIdx + 1)
            continue;
          
          var detailDistance = _writers.Get2(ii).DetailDistance;
          var distanceOffset = _writers.Get2(ii).DistanceOffset;

          var current = history[tailIdx];
          var next = history[tailIdx + 1];
          var percent = distanceOffset / detailDistance;
          
          _readers.Get1(i).Transform.position = Vector3.Lerp(current.Position, next.Position, percent);
          _readers.Get1(i).Transform.rotation = Quaternion.Lerp(current.Rotation, next.Rotation, percent);
        }
      }
    }
  }
}