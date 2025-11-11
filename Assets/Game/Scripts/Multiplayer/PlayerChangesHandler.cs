using System.Collections.Generic;
using System.Linq;
using Colyseus.Schema;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Multiplayer
{
  public class PlayerChangesHandler
  {
    private readonly string _playerId;
    private List<float> _receiveTimeIntervals = new (){0,0,0,0,0};
    private float _lastReceivedTime;

    public PlayerChangesHandler(string playerId)
    {
      _playerId = playerId;
    }

    public void OnPlayerChanged(List<DataChange> changes)
    {
      var interval = Time.time - _lastReceivedTime;
      _lastReceivedTime = Time.time;
      _receiveTimeIntervals.Add(interval);
      _receiveTimeIntervals.RemoveAt(0);
      
      ref var changeEvent = ref WorldHandler.GetWorld().NewEntity().Get<PlayerChangeEvent>();
      changeEvent.Id = _playerId;
      changeEvent.Changes = changes;
      changeEvent.AverageInterval = _receiveTimeIntervals.Sum() / _receiveTimeIntervals.Count;
    }
  }
}