using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Tail.Converters
{
  public class TailReaderConverter : MonoBehaviour, IConvertToEntity, ISnakePartSetup
  {
    private string _writerId;
    
    public void Convert(EcsEntity entity)
    {
      ref var component = ref entity.Get<TailReaderComponent>();
      component.TailWriterId =  _writerId;
    }

    public void Setup(SnakePartData data)
    {
      _writerId = data.HeadId;
    }
  }
}