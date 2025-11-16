using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Components
{
  public struct SpawnSnakeHeadEvent
  {
    public string Id;
    public Vector3 Position;
    public Player Player;
    public bool IsPlayer;
  }
}