using System.Collections.Generic;
using Colyseus.Schema;

namespace Game.Scripts.Gameplay.ECS.Common
{
  public struct AppleChangeEvent
  {
    public int Id;
    public List<DataChange> Changes;
  }
}