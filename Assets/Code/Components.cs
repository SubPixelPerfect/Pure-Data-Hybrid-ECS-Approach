using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Code{
  
  [Serializable]
  public struct Prefab : IComponentData{
    public int PrefabId;
  }
  
  [Serializable]
  public struct Scale : IComponentData{
    public float3 Value;
  }
  
  [Serializable]
  internal struct MousePress : IComponentData{
    public Entity target;
  }

  [Serializable]
  public struct BoxEmitterState : IComponentData{
    public float SpawnCooldown;
    public float SpawnInterval;
    public int SpawnedEntitiesCount;
    public int SpawnLimit;
  }
}