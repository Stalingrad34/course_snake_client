using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Game.Scripts.Infrastructure;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class SpawnSnakePartSystem : IEcsRunSystem
  {
    private EcsFilter<SpawnSnakePartEvent> _eventFilter;
    
    public void Run()
    {
      foreach (var i in _eventFilter)
      {
        var partView = AssetProvider.GetSnakePartView(_eventFilter.Get1(i).Prefab);
        partView.Setup(_eventFilter.Get1(i).PartData);
        partView.transform.position = _eventFilter.Get1(i).Position;
      }
    }
  }
}