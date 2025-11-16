using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class ForwardMoveableConverter : MonoBehaviour, IConvertToEntity, ISnakeHeadSetup
  {
    [SerializeField] private Transform direction;
    private float _speed;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<ForwardMoveableComponent>().Direction = direction;
      entity.Get<ForwardMoveableComponent>().Speed = _speed;
    }

    public void Setup(SnakeHeadData data)
    { 
      _speed = data.Speed; 
    }
  }
}