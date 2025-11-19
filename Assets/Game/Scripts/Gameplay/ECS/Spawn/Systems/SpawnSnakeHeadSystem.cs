using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Collision.Converters;
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
          Speed = _eventFilter.Get1(i).Player.speed,
          CollectRadius = 0.5f
        };
        
        var head = AssetProvider.GetSnakeHeadView();
        
        if (_eventFilter.Get1(i).IsPlayer)
        {
          head.gameObject.AddComponent<SphereCollisionConverter>();
          head.SetCamera(_mainCamera);
          var aim = AssetProvider.GetPlayerAimView();
          aim.Setup(headData);
          aim.transform.position = _eventFilter.Get1(i).Position;
          aim.transform.rotation = Quaternion.identity;
        }
        
        head.Setup(headData, _eventFilter.Get1(i).Player);
        head.SetColor(AssetProvider.GetPlayerData().Colors[_eventFilter.Get1(i).ColorIdx]);
        head.transform.position = _eventFilter.Get1(i).Position;
        head.transform.rotation = Quaternion.identity;

        for (int j = 0; j < _eventFilter.Get1(i).Player.parts; j++)
        {
          var partData = new SnakePartData()
          {
            HeadId = headData.Id
          };
          ref var spawnPartEvent = ref _world.NewEntity().Get<SpawnSnakePartEvent>();
          spawnPartEvent.Position = _eventFilter.Get1(i).Position;
          spawnPartEvent.Prefab = "Part";
          spawnPartEvent.PartData = partData;
          spawnPartEvent.ColorIdx = _eventFilter.Get1(i).ColorIdx;
        }
      }
    }
  }
}