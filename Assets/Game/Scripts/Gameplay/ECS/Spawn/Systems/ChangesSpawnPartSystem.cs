using System.Linq;
using Game.Scripts.Gameplay.Data;
using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Spawn.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.Spawn.Systems
{
  public class ChangesSpawnPartSystem : IEcsRunSystem
  {
    private EcsFilter<IdentifierComponent, TransformComponent> _snakes;
    private EcsFilter<PlayerChangeEvent> _filter;
    private EcsWorld _world;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var partsChange = _filter.Get1(i).Changes.FirstOrDefault(c => c.Field.Equals("parts"));
        if (partsChange == null)
          continue;
        
        var parts = (ushort)partsChange.Value - (ushort)partsChange.PreviousValue;
        if (parts <= 0)
          continue;
        
        foreach (var ii in _snakes)
        {
          if(!_snakes.Get1(i).Id.Equals(_filter.Get1(i).Id))
            continue;
          
          var partData = new SnakePartData()
          {
            HeadId = _filter.Get1(i).Id
          };

          for (int j = 0; j < parts; j++)
          {
            ref var spawnPartEvent = ref _world.NewEntity().Get<SpawnSnakePartEvent>();
            spawnPartEvent.Position = _snakes.Get2(ii).Transform.position;
            spawnPartEvent.Prefab = "Part";
            spawnPartEvent.PartData = partData;
            spawnPartEvent.ColorIdx = _filter.Get1(i).Player.color;
          }
        }
      }
    }
  }
}