using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure.Services;
using Game.Scripts.Multiplayer;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;
using Voody.UniLeo;

namespace Game.Scripts.Infrastructure.States
{
  public class MainState : IEnterStateAsync, IExitState
  {
    private MultiplayerManager _multiplayer;

    public async UniTask Enter()
    {
      await SceneManager.LoadSceneAsync("Battle");

      _multiplayer = ServiceProvider.Get<MultiplayerManager>();
      _multiplayer.OnPlayerConnected += OnPlayerConnected;
      _multiplayer.OnPlayerDisconnected += OnPlayerDisconnected;
      _multiplayer.OnAppleCreated += OnAppleCreated;
      _multiplayer.Connect(AssetProvider.GetPlayerData()).Forget();
    }

    private void OnPlayerConnected(string key, Player player)
    {
      ref var spawnEvent = ref WorldHandler.GetWorld().NewEntity().Get<SpawnSnakeHeadEvent>();
      spawnEvent.Id = key;
      spawnEvent.Position = new Vector3(player.pX, 0, player.pZ);
      spawnEvent.Player = player;
      spawnEvent.IsPlayer = _multiplayer.IsPlayer(key);
      spawnEvent.ColorIdx = player.color;
    }

    private void OnPlayerDisconnected(string key, Player player)
    {
      
    }
    
    private void OnAppleCreated(Apple data)
    {
      ref var spawnEvent = ref WorldHandler.GetWorld().NewEntity().Get<SpawnAppleEvent>();
      spawnEvent.Data = data;
    }

    public void Exit()
    {
      _multiplayer.OnPlayerConnected -= OnPlayerConnected;
      _multiplayer.OnPlayerDisconnected -= OnPlayerDisconnected;
      _multiplayer.Disconnect();
    }
  }
}