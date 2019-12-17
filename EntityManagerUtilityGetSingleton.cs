using Unity.Collections;
using Unity.Entities;

namespace E7.EcsGadgets
{
    public partial class EntityManagerUtility
    {
        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN>()
            where MAIN : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, TAG3>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, TAG3, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, TAG3, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, TAG3, TAG4>()
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>()
            ))
            {
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1>(SCD1 filter1)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>()
            ))
            {
                eq.SetSharedComponentFilter(filter1);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Like `GetSingleton` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided. The first type is always the returning value.
        /// </summary>
        public MAIN GetSingleton<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingleton<MAIN>();
            }
        }


        /// <summary>
        /// Like `GetSingletonEntity` in system but usable from outside.
        /// You can add more tag components and SCD constraints via
        /// overloads provided.
        /// </summary>
        public Entity GetSingletonEntity<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.GetSingletonEntity();
            }
        }


        /// <summary>
        /// Count entities that are returned from All query of
        /// all components in the overload you choose plus upto
        /// 2 SCD filters.
        /// </summary>
        public int EntityCount<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.CalculateEntityCount();
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<MAIN> ComponentDataArray<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1,
            SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized component data array of the first component.
        /// You can add additional tag components and upto 2 SCD filters to
        /// the query.
        /// 
        /// Returns managed array, you don't have to dispose it but
        /// it is not efficient for real use as it produces garbage.
        /// Good for unit testing.
        /// </summary>
        public MAIN[] Get<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToComponentDataArray<MAIN>(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public NativeArray<Entity> EntityArray<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                return eq.ToEntityArray(Allocator.Persistent);
            }
        }


        /// <summary>
        /// Return a linearized entity array of all components combined into All query.
        /// You can add upto 2 SCD filters to the query.
        /// 
        /// You have to dispose the returned native array.
        /// The returned native array will be allocated with Persistent allocator.
        /// </summary>
        public Entity[] Entities<MAIN, TAG1, TAG2, TAG3, TAG4, SCD1, SCD2>(SCD1 filter1, SCD2 filter2)
            where MAIN : struct, IComponentData
            where TAG1 : struct, IComponentData
            where TAG2 : struct, IComponentData
            where TAG3 : struct, IComponentData
            where TAG4 : struct, IComponentData
            where SCD1 : struct, ISharedComponentData
            where SCD2 : struct, ISharedComponentData
        {
            using (var eq = em.CreateEntityQuery(
                ComponentType.ReadOnly<MAIN>(),
                ComponentType.ReadOnly<TAG1>(),
                ComponentType.ReadOnly<TAG2>(),
                ComponentType.ReadOnly<TAG3>(),
                ComponentType.ReadOnly<TAG4>(),
                ComponentType.ReadOnly<SCD1>(),
                ComponentType.ReadOnly<SCD2>()
            ))
            {
                eq.SetSharedComponentFilter(filter1, filter2);
                var na = eq.ToEntityArray(Allocator.Persistent);
                var array = na.ToArray();
                na.Dispose();
                return array;
            }
        }
    }
}