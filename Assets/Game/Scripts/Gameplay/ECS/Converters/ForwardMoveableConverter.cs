using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class ForwardMoveableConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private Transform direction;
    [SerializeField] private float speed;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<ForwardMoveableComponent>().Direction = direction;
      entity.Get<ForwardMoveableComponent>().Speed = speed;
    }
  }
}