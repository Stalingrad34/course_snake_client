using System.Collections.Generic;
using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Tail.Converters
{
  public class TailWriterConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private Transform target;
    [SerializeField] private float detailDistance;
    
    public void Convert(EcsEntity entity)
    {
      ref var component = ref entity.Get<TailWriterComponent>();
      component.Target = target;
      component.DetailDistance = detailDistance;
      component.TransformHistory = new List<TransformPoint>(){new (transform)};
    }
  }
}