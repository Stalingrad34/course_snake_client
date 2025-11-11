
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnPlayerSystem : IEcsRunSystem
  {
    private EcsFilter<SpawnPlayerEvent> _eventFilter;
    private Camera _mainCamera;
    
    public void Run()
    {
      
    }
  }
}