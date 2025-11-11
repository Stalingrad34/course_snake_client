using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Rotate.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Rotate.Systems
{
  public class ControlRotateSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent, RotatableComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var posX = _filter.Get1(i).MousePosition.x;
        var posZ = _filter.Get1(i).MousePosition.y;
        _filter.Get2(i).Destination = new Vector3(posX, 0, posZ);
      }
    }
  }
}