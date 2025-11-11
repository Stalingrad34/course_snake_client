using System;
using System.Collections.Generic;
using Colyseus;
using Cysharp.Threading.Tasks;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.Services;
using Newtonsoft.Json;

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

    public async UniTaskVoid Connect()
    {
      
    }

    public void Disconnect()
    {
      if (_room == null)
        return;
      
      _room.Leave().AsUniTask().Forget();
      _changesHandlers.Clear();
    }
    
    public bool IsPlayer(string key)
    {
      return key.Equals(_room?.SessionId);
    }
  }
}
