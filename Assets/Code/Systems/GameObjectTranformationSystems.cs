using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Code.Systems{  
  
  public struct GoData{
    public ComponentDataArray<Prefab> Pr;
    public EntityArray Entities;
    public int Length;
  }
  
  [UpdateAfter(typeof(GameObjectManagerSystem))]
  public class GameObjectTranformationWriteSystem:ComponentSystem{
    
    [Inject] private GoData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        if( EntityManager.HasComponent<Position>( e ) ){
          go.GetComponent<Transform>().position =
            EntityManager.GetComponentData<Position>( e ).Value;
        }
        if( EntityManager.HasComponent<Rotation>( e ) ){
          go.GetComponent<Transform>().rotation =
            EntityManager.GetComponentData<Rotation>( e ).Value;
        }
        if( EntityManager.HasComponent<Scale>( e ) ){
          go.GetComponent<Transform>().localScale =
            EntityManager.GetComponentData<Scale>( e ).Value;
        }
      }
    }
  }
  
  [UpdateAfter(typeof(FixedUpdate))]
  public class GameObjectTranformationReadSystem:ComponentSystem{
    
    [Inject] private GoData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        
        if( EntityManager.HasComponent<Position>( e ) )
          EntityManager.SetComponentData(e, 
            new Position(){Value = go.GetComponent<Transform>().position});
        
        if( EntityManager.HasComponent<Rotation>( e ) )
          EntityManager.SetComponentData(e, 
            new Rotation(){Value = go.GetComponent<Transform>().rotation});
        
        if( EntityManager.HasComponent<Scale>( e ) )
          EntityManager.SetComponentData(e, 
            new Scale(){Value = go.GetComponent<Transform>().localScale});
        
      }
    }
  }
  
  
  
  
  /*
  // минус делать это поотдельности в том что
  // для каждого свойства мы ищем геймобджек в словаре
  
  public struct GoPositionsData{
    public ComponentDataArray<Prefab> GOs;
    public ComponentDataArray<Position> Positions;
    public EntityArray Entities;
    public int Length;
  }
  
  [UpdateAfter(typeof(GameObjectManagerSystem))]
  public class GameObjectTranformationPositionWriteSystem:ComponentSystem{
    
    [Inject] private GoPositionsData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        go.GetComponent<Transform>().position = _data.Positions[i].Value;
      }
    }
  }
  
  [UpdateAfter(typeof(FixedUpdate))]
  public class GameObjectTranformationPositionReadSystem:ComponentSystem{
    
    [Inject] private GoPositionsData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        Position p = new Position(){Value = go.GetComponent<Transform>().position};
        EntityManager.SetComponentData(e, p);
      }
    }
  }
  
  
  
  
  
  
  
  public struct GoRotationData{
    public ComponentDataArray<Prefab> GOs;
    public ComponentDataArray<Rotation> Rotattions;
    public EntityArray Entities;
    public int Length;
  }
  
  [UpdateAfter(typeof(GameObjectManagerSystem))]
  public class GameObjectTranformationRotationWriteSystem:ComponentSystem{
    
    [Inject] private GoRotationData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        go.GetComponent<Transform>().rotation = _data.Rotattions[i].Value;
      }
    }
  }
  
  [UpdateAfter(typeof(FixedUpdate))]
  public class GameObjectTranformationRotationReadSystem:ComponentSystem{
    
    [Inject] private GoRotationData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        Rotation rotation = new Rotation(){Value = go.GetComponent<Transform>().rotation};
        EntityManager.SetComponentData(e, rotation);
      }
    }
  }
  
  
  
  
  
  
  public struct GoScaleData{
    public ComponentDataArray<Prefab> GOs;
    public ComponentDataArray<Scale> Scales;
    public EntityArray Entities;
    public int Length;
  }
  
  [UpdateAfter(typeof(GameObjectManagerSystem))]
  public class GameObjectTranformationScaleWriteSystem:ComponentSystem{
    
    [Inject] private GoScaleData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;
    
    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        go.GetComponent<Transform>().localScale = _data.Scales[i].Value;
      }
    }
  }
  
  [UpdateAfter(typeof(FixedUpdate))]
  public class GameObjectTranformationScaleReadSystem:ComponentSystem{
    
    [Inject] private GoScaleData _data;
    [Inject] private GameObjectManagerSystem _gameObjectManagerSys;
    
    protected override void OnUpdate(){
      for( int i = 0; i != _data.Length; i++ ){
        Entity e = _data.Entities[i];
        GameObject go = _gameObjectManagerSys.GameObjects[e];
        Scale scale = new Scale(){Value = go.GetComponent<Transform>().localScale};
        EntityManager.SetComponentData(e, scale);
      }
    }
  }
  
  */  
  
  
}