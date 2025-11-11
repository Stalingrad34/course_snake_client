using Game.Scripts.Gameplay.ECS.Input.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Input.Systems
{
  public class MouseSystem : IEcsRunSystem
  {
    private EcsFilter<ControlComponent> _filter;
    private Camera _camera;
    
    public void Run()
    {
      if (UnityEngine.Input.GetMouseButton(0))
      {
        foreach (var i in _filter)
        {
          var plane = new Plane(Vector3.up, Vector3.zero);
          
          var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
          plane.Raycast(ray, out var distance);
          var point = ray.GetPoint(distance);
          _filter.Get1(i).MousePosition = new Vector2(point.x, point.z);
        }
      }
    }
  }
}