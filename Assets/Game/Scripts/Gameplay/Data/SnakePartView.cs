using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
  public class SnakePartView : MonoBehaviour
  {
    public void Setup(SnakePartData data)
    {
      var setupComponents = gameObject.GetComponents<ISnakePartSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }
  }
}