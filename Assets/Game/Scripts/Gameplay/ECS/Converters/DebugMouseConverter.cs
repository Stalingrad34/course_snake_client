using Game.Scripts.Gameplay.ECS.Input.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS.Converters
{
  public class DebugMouseConverter : MonoBehaviour, IConvertToEntity
  {
    public void Convert(EcsEntity entity)
    {
      entity.Get<DebugMouseComponent>();
    }
  }
}