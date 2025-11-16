using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
  public struct TransformPoint
  {
    public readonly Vector3 Position;
    public readonly Quaternion Rotation;
    
    public TransformPoint(Vector3 position, Quaternion rotation)
    {
      Position = position;
      Rotation = rotation;
    }

    public TransformPoint(Transform transform)
    {
      Position = transform.position;
      Rotation = transform.rotation;
    }
  }
}