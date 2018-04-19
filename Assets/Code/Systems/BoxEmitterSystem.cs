using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Code.Systems{
  public class BoxEmitterSystem : ComponentSystem{
    public static EntityArchetype BoxArchetype;

    private struct Data{
      public ComponentDataArray<BoxEmitterState> State;
    }
    [Inject] private Data _data;

    protected override void OnCreateManager( int capacity ){
      BoxArchetype = EntityManager.CreateArchetype(
        typeof( Prefab ),
        typeof( Position )
      );

      var initialState = new BoxEmitterState{
        SpawnedEntitiesCount = 0,
        SpawnLimit = 250,
        SpawnCooldown = 0,
        SpawnInterval = .025f
      };

      var stateEntity = EntityManager.CreateEntity( typeof( BoxEmitterState ) );
      EntityManager.SetComponentData( stateEntity, initialState );
    }

    protected override void OnUpdate(){
      
      var state = _data.State[0];
      if( state.SpawnedEntitiesCount >= state.SpawnLimit ) return;

      state.SpawnCooldown -= Time.deltaTime;
      if( state.SpawnCooldown > 0.0f ){
        _data.State[0] = state;
        return;
      }

      state.SpawnCooldown = state.SpawnInterval;
      state.SpawnedEntitiesCount++;

      _data.State[0] = state;

      var rnd = Random.insideUnitCircle * 3;
      var pos = new float3( rnd.x, Random.value * 7 + 6, rnd.y );
      PostUpdateCommands.CreateEntity( BoxArchetype );
      PostUpdateCommands.SetComponent( new Prefab{PrefabId = 0} );
      PostUpdateCommands.SetComponent( new Position{Value = pos} );
    }


  }
}