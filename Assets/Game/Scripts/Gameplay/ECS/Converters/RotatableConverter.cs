using Game.Scripts.Gameplay.ECS.Rotate.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class RotatableConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private Transform target;
    [SerializeField] private float rotateSpeed;
    
    public void Convert(EcsEntity entity)
    {
      ref var component = ref entity.Get<RotatableComponent>();
      component.Target = target;
      component.Speed = rotateSpeed;
    }
  }
}