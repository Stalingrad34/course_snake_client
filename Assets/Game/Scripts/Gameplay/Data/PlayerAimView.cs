using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
  public class PlayerAimView : MonoBehaviour
  {
    public void Setup(SnakeHeadData data)
    {
      var setupComponents = gameObject.GetComponents<ISnakeHeadSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }
  }
}