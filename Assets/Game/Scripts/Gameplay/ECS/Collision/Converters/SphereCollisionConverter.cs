using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Collision.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Collision.Converters
{
  public class SphereCollisionConverter : MonoBehaviour, IConvertToEntity, ISnakeHeadSetup
  {
    private float _radius;
    
    public void Convert(EcsEntity entity)
    {
      ref var component = ref entity.Get<SphereCollisionComponent>();
      component.Radius = _radius;
      component.Target = transform;
    }

    public void Setup(SnakeHeadData data)
    {
      _radius = data.CollectRadius;
    }
  }
}