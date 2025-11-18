using System;
using System.Collections.Generic;
using Colyseus.Schema;
using Game.Scripts.Gameplay.ECS.Common;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Game.Scripts.Multiplayer
{
  public class AppleChangesHandler : IDisposable
  {
    private readonly int _appleId;
    private readonly Apple _apple;

    public AppleChangesHandler(Apple apple)
    {
      _appleId = (int)apple.id;
      _apple = apple;
      apple.OnChange += OnAppleChanged;
    }

    private void OnAppleChanged(List<DataChange> changes)
    {
      ref var changeEvent = ref WorldHandler.GetWorld().NewEntity().Get<AppleChangeEvent>();
      changeEvent.Id = _appleId;
      changeEvent.Changes = changes;
    }

    public void Dispose()
    {
      _apple.OnChange -= OnAppleChanged;
    }
  }
}