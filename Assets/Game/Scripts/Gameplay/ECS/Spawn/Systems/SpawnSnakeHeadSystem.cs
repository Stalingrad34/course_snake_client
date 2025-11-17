using Game.Scripts.Gameplay.Data;
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
        head.SetColor(AssetProvider.GetPlayerData().Colors[_eventFilter.Get1(i).ColorIdx]);
        head.transform.position = _eventFilter.Get1(i).Position;

        if (_eventFilter.Get1(i).IsPlayer)
        {
          head.SetCamera(_mainCamera);
          var aim = AssetProvider.GetPlayerAimView();
          aim.Setup(headData);
          aim.transform.position = _eventFilter.Get1(i).Position;
        }

        for (int j = 0; j < _eventFilter.Get1(i).Player.p; j++)
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