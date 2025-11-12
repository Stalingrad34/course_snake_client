using System.Collections.Generic;
using Game.Scripts.Gameplay.ECS.Tail.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Tail.Converters
{
  public class TailConverter : MonoBehaviour, IConvertToEntity
  {
    [SerializeField] private Transform target;
    [SerializeField] private List<Transform> details;
    [SerializeField] private float detailDistance;
    
    public void Convert(EcsEntity entity)
    {
      var history = new List<Vector3>();
      history.Add(target.position);
      foreach (var detail in details)
      {
        history.Add(detail.position);
      }
      
      ref var component = ref entity.Get<TailComponent>();
      component.Target = target;
      component.Details = details;
      component.DetailDistance = detailDistance;
      component.PositionHistory = history;
    }
  }
}