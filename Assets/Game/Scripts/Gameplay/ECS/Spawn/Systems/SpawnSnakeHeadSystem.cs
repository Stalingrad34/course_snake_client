using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Converters;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnSnakeHeadSystem : IEcsRunSystem
  {
    private EcsFilter<SpawnSnakeHeadEvent> _eventFilter;
    private EcsWorld _world;
    private Camera _mainCamera;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        var headData = new SnakeHeadData()
        {
          Id = _eventFilter.Get1(i).Id,
          Speed = _eventFilter.Get1(i).Player.speed
        };
        
        var head = AssetProvider.GetSnakeHeadView();
        head.Setup(headData);
        head.transform.position = _eventFilter.Get1(i).Position;

        if (_eventFilter.Get1(i).IsPlayer)
        {
          head.gameObject.AddComponent<ControlConverter>();
          head.gameObject.AddComponent<SendDataConverter>();
          head.SetCamera(_mainCamera);
        }
        else
        {
          head.gameObject.AddComponent<ServerPlayerConverter>();
        }

        CreateSpawnSnakePartEvent(headData.Id, _eventFilter.Get1(i).Position, "Tail");

        for (int j = 0; j < _eventFilter.Get1(i).Player.p; j++)
        {
          CreateSpawnSnakePartEvent(headData.Id, _eventFilter.Get1(i).Position, "Part");
        }
      }
    }

    private void CreateSpawnSnakePartEvent(string headId, Vector3 position, string prefab)
    {
      var tailData = new SnakePartData()
      {
        HeadId = headId
      };
        
      ref var tailSpawn = ref _world.NewEntity().Get<SpawnSnakePartEvent>();
      tailSpawn.Prefab = prefab;
      tailSpawn.Position = position;
      tailSpawn.PartData = tailData;
    }
  }
}