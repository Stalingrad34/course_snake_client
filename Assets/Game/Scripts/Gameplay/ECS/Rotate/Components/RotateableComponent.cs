using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Rotate.Components
{
  public struct RotatableComponent
  {
    public Transform Target;
    public Vector3 Destination;
    public float Speed;
  }
}