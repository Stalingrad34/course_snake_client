using Game.Scripts.Gameplay.ECS.Collect.Components;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Collect.Systems
{
  public class ChangesAppleSystem : IEcsRunSystem
  {
    private EcsFilter<TransformComponent, CollectAppleComponent> _applesFilter;
    private EcsFilter<AppleChangeEvent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        foreach (var ii in _applesFilter)
        {
          if (_filter.Get1(i).Id != _applesFilter.Get2(ii).Id)
            continue;
          
          foreach (var change in _filter.Get1(i).Changes)
          {
            switch (change.Field)
            {
              case "position":
                var position = (Vector2Float)change.Value;
                _applesFilter.Get1(ii).Transform.position = new Vector3(position.x, 0, position.z);
                _applesFilter.Get1(ii).Transform.gameObject.SetActive(true);
                break;
            }
          }
        }
      }
    }
  }
}