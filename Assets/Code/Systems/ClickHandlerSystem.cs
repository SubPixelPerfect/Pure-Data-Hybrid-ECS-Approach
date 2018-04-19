using Unity.Entities;
using UnityEngine;

namespace Code.Systems{
  public class ClickHandlerSystem : ComponentSystem{

    private struct Data{
      public int Length;
      public ComponentDataArray<MousePress> mousePressEvents;
      public EntityArray entities;
    }
    [Inject] private Data _data;

    protected override void OnUpdate(){
      for( var i = 0; i != _data.Length; i++ ){
        var target = _data.mousePressEvents[i].target;

        //Debug.Log( "Click on :" + target.Index );
        PostUpdateCommands.DestroyEntity( _data.entities[i] );
        PostUpdateCommands.DestroyEntity( target );
      }
    }
  }
}