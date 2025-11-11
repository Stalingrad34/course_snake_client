using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnEnemySystem : IEcsRunSystem
  {
    private EcsFilter<SpawnEnemyEvent> _eventFilter;
    
    public void Run()
    {
      
    }
  }
}