using Code.Systems;
using Code.WorldBootstrapp;
using Unity.Entities;

namespace Code{
  public class HybridWorld : BootstrapperBase{
    protected override World OnCreateWorld(){
      SetWorldActive = true;
      return new World( "Hybrid World" );
    }

    protected override void OnRegisterSystems(){
      
      RegisterSystem<BoxEmitterSystem>();
      RegisterSystem<GameObjectManagerSystem>();
      RegisterSystem<GameObjectTranformationReadSystem>();
      RegisterSystem<GameObjectTranformationWriteSystem>();
      RegisterSystem<ClickHandlerSystem>();


      // Unity Systems
//      RegisterSystem<HeadingSystem>();
//      RegisterSystem<MoveForwardSystem>();
//      RegisterSystem<TransformInputBarrier>();
//      RegisterSystem<TransformSystem>();
//      RegisterSystem<MeshInstanceRendererSystem>();
//      RegisterSystem<MoveForward2DSystem>();
//      RegisterSystem<Transform2DSystem>();
//      RegisterSystem<CopyInitialTransformFromGameObjectSystem>();
//      RegisterSystem<CopyTransformFromGameObjectSystem>();
//      RegisterSystem<CopyTransformToGameObjectSystem>();
      
      
    }
  }
}