using System.Linq;
using Code.Systems;
using Unity.Entities;
using UnityEngine;

namespace Code{
  public class MouseEventsGenerator : MonoBehaviour{
    private void OnMouseDown(){
      var entity = World.Active.GetExistingManager<GameObjectManagerSystem>().GameObjects
        .First( kvp => kvp.Value == gameObject ).Key;
      var em = World.Active.GetExistingManager<EntityManager>();

      var evt = em.CreateEntity( typeof( MousePress ) );
      em.SetComponentData( evt, new MousePress{target = entity} );
    }
  }
}