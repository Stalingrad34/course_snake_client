using Game.Scripts.Gameplay.ECS.Common;
using Game.Scripts.Gameplay.ECS.SendMessage.Components;
using Leopotam.Ecs;

namespace Game.Scripts.Gameplay.ECS.SendMessage.Systems
{
  public class SendMoveSystem : IEcsRunSystem
  {
    private EcsFilter<SendDataComponent, TransformComponent, RigidbodyComponent> _filter;
    
    public void Run()
    {
      foreach (var i in _filter)
      {
        var transform = _filter.Get2(i).Transform;
        var rigidbody = _filter.Get3(i).Rigidbody;
        _filter.Get1(i).SendData["pX"] = transform.position.x;
        _filter.Get1(i).SendData["pY"] = transform.position.y;
        _filter.Get1(i).SendData["pZ"] = transform.position.z;
        _filter.Get1(i).SendData["vX"] = rigidbody.linearVelocity.x;
        _filter.Get1(i).SendData["vY"] = rigidbody.linearVelocity.y;
        _filter.Get1(i).SendData["vZ"] = rigidbody.linearVelocity.z;
      }
    }
  }
}