using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Input.Systems
{
  public class DebugMouseSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, DebugMouseComponent, ControlComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var mousePosition = _filter.Get3(i).MousePosition;
        var position = new Vector3(mousePosition.x, 0, mousePosition.y);
        _filter.Get1(i).Transform.position = position;
      }
    }
  }
}