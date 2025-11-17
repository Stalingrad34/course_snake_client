using Game.Scripts.Gameplay.Data;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Components
{
  public struct SpawnSnakePartEvent
  {
    public string Prefab;
    public Vector3 Position;
    public SnakePartData PartData;
    public int ColorIdx;
  }
}