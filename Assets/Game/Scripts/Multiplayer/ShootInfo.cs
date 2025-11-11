using System;

namespace Game.Scripts.Multiplayer
{
  [Serializable]
  public struct ShootInfo
  {
    public string key;
    public float pX;
    public float pY;
    public float pZ;
    public float dX;
    public float dY;
    public float dZ;
  }
}