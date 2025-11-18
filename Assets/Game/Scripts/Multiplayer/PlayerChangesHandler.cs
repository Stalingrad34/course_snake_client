using System;
using System.Collections.Generic;
using System.Linq;
using Colyseus.Schema;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Multiplayer
{
  public class PlayerChangesHandler : IDisposable
  {
    private readonly string _playerId;
    private readonly Player _player;
    private List<float> _receiveTimeIntervals = new (){0,0,0,0,0};
    private float _lastReceivedTime;

    public PlayerChangesHandler(string playerId, Player player)
    {
      _playerId = playerId;
      _player = player;
      player.OnChange += OnPlayerChanged;
    }

    private void OnPlayerChanged(List<DataChange> changes)
    {
      var interval = Time.time - _lastReceivedTime;
      _lastReceivedTime = Time.time;
      _receiveTimeIntervals.Add(interval);
      _receiveTimeIntervals.RemoveAt(0);
      
      ref var changeEvent = ref WorldHandler.GetWorld().NewEntity().Get<PlayerChangeEvent>();
      changeEvent.Id = _playerId;
      changeEvent.Changes = changes;
    }

    public void Dispose()
    {
      _player.OnChange -= OnPlayerChanged;
    }
  }
}