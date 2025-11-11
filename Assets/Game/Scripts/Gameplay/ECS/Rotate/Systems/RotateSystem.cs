using Game.Scripts.Gameplay.ECS.Rotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Rotate.Systems
{
  public class RotateSystem : IEcsRunSystem
  {
    private EcsFilter<RotatableComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var target =  _filter.Get1(i).Target;
        var destination = _filter.Get1(i).Destination;

        var targetRotation = Quaternion.LookRotation(destination - target.position);
        target.rotation = Quaternion.RotateTowards(target.rotation, targetRotation, Time.deltaTime * _filter.Get1(i).Speed);
      }
    }
  }
}