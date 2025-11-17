using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
  public class SnakePartView : MonoBehaviour
  {
    [SerializeField] private List<MeshRenderer> materials;
    
    public void Setup(SnakePartData data)
    {
      var setupComponents = gameObject.GetComponents<ISnakePartSetup>();
      foreach (var setupComponent in setupComponents)
      {
        setupComponent.Setup(data);
      }
    }
    
    public void SetColor(Color color)
    {
      materials.ForEach(m => m.material.SetColor("_BaseColor", color));
    }
  }
}