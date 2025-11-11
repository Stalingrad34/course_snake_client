using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Move.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Move.Systems
{
  public class ForwardMoveSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, ForwardMoveableComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var transform = _filter.Get1(i).Transform;
        var direction = _filter.Get2(i).Direction;
        transform.position += direction.forward * _filter.Get2(i).Speed * Time.deltaTime;
      }
    }
  }
}