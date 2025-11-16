using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Input.Components;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Input.Systems
{
  public class DebugAddPartSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, TransformComponent, ControlComponent> _filter;
    
    public void Run()
    {
      if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
      {
        foreach (var i in _filter)
        {
          var partData = new SnakePartData()
          {
            HeadId = _filter.Get1(i).Id
          };
          
          ref var spawnEvent = ref _filter.GetEntity(i).Get<SpawnSnakePartEvent>();
          spawnEvent.Prefab = "Part";
          spawnEvent.Position = _filter.Get2(i).Transform.position;
          spawnEvent.PartData = partData;
        }
      }
    }
  }
}