using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Collect.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Collect.Converters
{
  public class CollectAppleConverter : MonoBehaviour, IConvertToEntity, IAppleSetup
  {
    private int _id;
    
    public void Convert(EcsEntity entity)
    {
      entity.Get<CollectAppleComponent>().Id = _id;
    }

    public void Setup(AppleData data)
    {
      _id = data.Id;
    }
  }
}