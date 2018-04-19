# Sample of Pure-Data-Hybrid Ecs Approach 

Istead of using GameObjectEntity which adds ObjectComponents to Entities

it operates on pure IDataComonents 
and uses GameObject-Wrapper-Systems that maintain GameObjects internally for rendering, phisics and collision detection 

benefits of this aproach
- It respaects data oriented design - data strictly sepatated form logic
- It makes serialisation/deserealisation of an entity to be a simple thing
- You can use Jobs
