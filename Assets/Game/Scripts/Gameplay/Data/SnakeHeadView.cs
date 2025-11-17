using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
  public class SnakeHeadView : MonoBehaviour
  {
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private List<MeshRenderer> materials;
    
    public void SetCamera(Camera gameCamera)
    {
      gameCamera.transform.SetParent(cameraPoint);
      gameCamera.transform.localPosition = Vector3.up * gameCamera.transform.position.y;
    }
    
    public void Setup(SnakeHeadData data)
    {
      var setupComponents = gameObject.GetComponents<ISnakeHeadSetup>();
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