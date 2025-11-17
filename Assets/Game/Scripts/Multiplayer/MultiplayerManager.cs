using System;
using System.Collections.Generic;
using Colyseus;
using Cysharp.Threading.Tasks;
using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.Services;
using Newtonsoft.Json;
using Sirenix.Utilities;

namespace Game.Scripts.Multiplayer
{
  public class MultiplayerManager : ColyseusManager<MultiplayerManager>, IService
  {
    public event Action<string, Player> OnPlayerConnected;
    public event Action<string, Player> OnPlayerDisconnected;
    public event Action<RestartInfo> OnRestartMessageReceived;
    
    private readonly Dictionary<string, PlayerChangesHandler> _changesHandlers = new();
    private ColyseusRoom<State> _room;
    
    public void Init()
    {
      Instance.InitializeClient();

#if UNITY_EDITOR
      ApplicationLifecycleProvider.ApplicationQuit += Disconnect;
#endif
    }

    public async UniTaskVoid Connect(PlayerData playerData)
    {
      var data = new Dictionary<string, object>()
      {
        {"speed", playerData.Speed},
        {"parts", 1},
        {"colorsLength", playerData.Colors.Length},
      };
      
      _room = await client.JoinOrCreate<State>("state_handler", data);
      
      _room.OnStateChange += OnChange;
      _room.State.players.OnAdd += OnPlayerAdd;
      _room.State.players.OnRemove += OnPlayerRemove;
      _room.State.players.ForEach(OnPlayerAdd);
    }
    
    public void SendMessage(string key, Dictionary<string, object> data)
    {
      _room.Send(key, data);
    }
    
    private void OnPlayerAdd(string key, Player player)
    {
      var handler = new PlayerChangesHandler(key, player);
      _changesHandlers.Add(key, handler);
      OnPlayerConnected?.Invoke(key, player);
    }
    
    private void OnPlayerRemove(string key, Player player)
    {
      _changesHandlers.Remove(key);
      OnPlayerDisconnected?.Invoke(key, player);
    }
    
    private void OnChange(State state, bool isFirstState)
    {
      
    }

    public void Disconnect()
    {
      if (_room == null)
        return;
      
      _room.Leave().AsUniTask().Forget();
      _changesHandlers.Values.ForEach(h => h.Dispose());
      _changesHandlers.Clear();
    }
    
    public bool IsPlayer(string key)
    {
      return key.Equals(_room?.SessionId);
    }
  }
}
