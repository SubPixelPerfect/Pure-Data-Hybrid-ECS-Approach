# Sample of Pure-Data-Hybrid Ecs Approach 

Instead of using GameObjectEntity, which allow you to add Components to Entities, this project operates on IComponentData structs which in turn uses GameObject-Wrapper-Systems that maintain GameObjects internally for rendering, physics and collision detection. 

benefits of this aproach
- It respects data oriented design - data is strictly sepatated from behavior
- It makes serialisation/deserealisation of an entity a simple thing
- You can use Jobs
