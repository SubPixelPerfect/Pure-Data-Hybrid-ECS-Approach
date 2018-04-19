using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Code.Systems{
  
  // инстанциирует префабы и уничтожает ненужные геймобджекты
  // потом можно добавить пул для инстансов префабов
  [AlwaysUpdateSystem]
  [UpdateBefore(typeof(EarlyUpdate))]
  public class GameObjectManagerSystem:ComponentSystem{
    
    public Dictionary<Entity, GameObject> GameObjects = new Dictionary<Entity, GameObject>();
    
    public struct Data{
      public ComponentDataArray<Prefab> Prefabs;
      public EntityArray Entities;
      public int Length;
    }

    [Inject] private Data _data;
    
    protected override void OnUpdate(){
      
      // инстанциировать префабы для тех энтити у которых нет геймобджекта 
      for( int i = 0; i != _data.Length; i++ ){
        Prefab prefab = _data.Prefabs[i];
        Entity entity = _data.Entities[i];
        if(!GameObjects.ContainsKey( entity )){
          var instance = Object.Instantiate( PrefabsList.instance.prefabs[prefab.PrefabId] );
          GameObjects.Add( entity, instance );
        }
      }
      
      // удалить геймобджекты у которых больше нету соответсвующего энтити 
      if( GameObjects.Count > _data.Length ){// сравнить количество энтити и геймобджектов
        
        // если геймобджектов больше чем энтити
        // значит надо что-то удалить
        Entity[] eee = new Entity[_data.Length];
        for( int i = 0; i != _data.Length; i++ ){
          eee[i] = _data.Entities[i];
        }
        var gameObjectsToRemove = GameObjects.Keys.Except( eee ).ToArray();
        
        foreach( var entity in gameObjectsToRemove ){
          Object.Destroy( GameObjects[entity].gameObject ); // destroy game object
          GameObjects.Remove( entity ); // and forget about it
        }
      }
    }
    
  }
  
  
}