using System;
using Core.Scripts.Loggers;
using Game.Scripts.Gameplay.ECS.Collect;
using Game.Scripts.Gameplay.ECS.Collision;
using Game.Scripts.Gameplay.ECS.Collision.Components;
using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.Input;
using Game.Scripts.Gameplay.ECS.Move;
using Game.Scripts.Gameplay.ECS.Rotate;
using Game.Scripts.Gameplay.ECS.SendMessage;
using Game.Scripts.Gameplay.ECS.Spawn;
using Game.Scripts.Gameplay.ECS.Tail;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;
using Voody.UniLeo;

namespace Game.Scripts.Gameplay.ECS
{
  public class ECSRunner : MonoBehaviour
  {
    [SerializeField] private Camera mainCamera;
    
    private EcsWorld _world;
    private EcsSystems _systems;
    private EcsSystems _physicSystems;
    
    private bool _hasException;

    private void Awake()
    {
      _world = new EcsWorld();

#if UNITY_EDITOR
      EcsWorldObserver.Create(_world);
#endif

      _systems = new EcsSystems(_world);
      _systems
        .Add(new InputFeature())
        .Add(new SpawnFeature())
        .Add(new MoveFeature())
        .Add(new RotateFeature())
        .Add(new TailFeature())
        .Add(new CollectFeature())
        .Add(new SendMessageFeature())
        .OneFrame<PlayerChangeEvent>()
        .OneFrame<CollisionEvent>()
        .Inject(mainCamera)
        .ConvertScene()
        .Init();

      _physicSystems = new EcsSystems(_world);
      _physicSystems
        .Add(new CollisionFeature())
        .Init();

#if UNITY_EDITOR
      EcsSystemsObserver.Create(_systems);
#endif
    }

    private void Update()
    {
      if (_hasException)
        return;

      try
      {
        _systems?.Run();
      }
      catch (Exception e)
      {
        _hasException = true;
        ECSLogger.ShowLogs();
        throw new UnityException(e.ToString());
      }
    }

    private void FixedUpdate()
    {
      if (_hasException)
        return;

      try
      {
        _physicSystems?.Run();
      }
      catch (Exception e)
      {
        _hasException = true;
        ECSLogger.ShowLogs();
        throw new UnityException(e.ToString());
      }
    }

    private void OnDestroy()
    {
      _systems?.Destroy();
      _world?.Destroy();
    }
  }
}