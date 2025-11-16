using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Tail.Systems
{
  public class TailLengthSystem : IEcsRunSystem
  {
    private EcsFilter<TailReaderComponent> _readers;
    private EcsFilter<IdentifierComponent, TailWriterComponent> _writers;
    
    public void Run()
    {
      foreach (var i in _readers)
      {
        if (_readers.Get1(i).TailIdx.HasValue)
          continue;

        var writerId = _readers.Get1(i).TailWriterId;
        foreach (var ii in _writers)
        {
          if (!_writers.Get1(ii).Id.Equals(writerId))
            continue;
          
          _writers.Get2(ii).Length++;
          _readers.Get1(i).TailIdx = _writers.Get2(ii).Length - 1;
        }
      }
    }
  }
}