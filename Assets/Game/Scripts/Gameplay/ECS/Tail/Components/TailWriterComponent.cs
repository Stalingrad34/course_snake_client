using System.Collections.Generic;
using Game.Scripts.Gameplay.Data;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Tail.Components
{
  public struct TailWriterComponent
  {
    public Transform Target;
    public float DetailDistance;
    public List<TransformPoint> TransformHistory;
    public float DistanceOffset;
    public int Length;
  }
}