using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Tail.Components
{
  public struct TailComponent
  {
    public Transform Target;
    public List<Transform> Details;
    public float DetailDistance;
    public List<Vector3> PositionHistory;
    public float DistanceOffset;
  }
}