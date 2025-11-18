using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
  public class AppleView : MonoBehaviour
  {
    public void Setup(AppleData data)
    {
      var setupComponents = gameObject.GetComponents<IAppleSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }
  }
}