using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnAppleSystem : IEcsRunSystem
  {
    private EcsFilter<SpawnAppleEvent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var appleView = AssetProvider.GetAppleView();
        var appleData = new AppleData()
        {
          Id = (int)_filter.Get1(i).Data.id
        };
        appleView.Setup(appleData);
        var position = _filter.Get1(i).Data.position;
        appleView.transform.position = new Vector3(position.x, 0, position.z);
      }
    }
  }
}