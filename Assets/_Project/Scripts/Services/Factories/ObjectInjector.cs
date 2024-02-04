using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Services.Factories
{
    public class ObjectInjector
    {
        /*public object Resolve(
            IObjectResolver objectResolver, 
            Type objectType, 
            bool tryManually = false, 
            bool allowExceptions = true)
        {
            object resolved = null;
            try
            {
                resolved = objectResolver.Resolve(objectType);
            }
            catch
            {
                if (allowExceptions)
                    throw;
            }

            if (resolved == null && tryManually)
                return Activator.CreateInstance(objectType);

            return resolved;
        }        
        
        public T Resolve<T>(
            IObjectResolver objectResolver, 
            bool tryManually = false, 
            bool allowExceptions = true) 
            where T : class
        {
            T resolved = null;
            try
            {
                resolved = objectResolver.Resolve<T>();
            }
            catch
            {
                if (allowExceptions)
                    throw;
            }

            if (resolved == null && tryManually)
                return Activator.CreateInstance<T>();

            return resolved;
        }*/
        
        public T Instantiate<T>(
            IObjectResolver objectResolver, 
            T prefab)
            where T : Component
        {
            T component = Object.Instantiate(prefab);
            objectResolver.InjectGameObject(component.gameObject);
            return component;
        }

        public T Instantiate<T>(
            IObjectResolver objectResolver, 
            T prefab, 
            Transform parent, 
            bool worldPositionStays = false)
            where T : Component
        {
            T component = Object.Instantiate(prefab, parent, worldPositionStays);
            objectResolver.InjectGameObject(component.gameObject);
            return component;
        }

        public T Instantiate<T>(
            IObjectResolver objectResolver, 
            T prefab,
            Vector3 position,
            Quaternion rotation)
            where T : Component
        {
            T component = Object.Instantiate(prefab, position, rotation);
            objectResolver.InjectGameObject(component.gameObject);
            return component;
        }

        public T Instantiate<T>(
            IObjectResolver objectResolver, 
            T prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent)
            where T : Component
        {
            T component = Object.Instantiate(prefab, position, rotation, parent);
            objectResolver.InjectGameObject(component.gameObject);
            return component;
        }
        
        public GameObject Instantiate(
            IObjectResolver objectResolver, 
            GameObject prefab)
        {
            GameObject obj = Object.Instantiate(prefab);
            objectResolver.InjectGameObject(obj);
            return obj;
        }

        public GameObject Instantiate(
            IObjectResolver objectResolver, 
            GameObject prefab, 
            Transform parent, 
            bool worldPositionStays = false)
        {
            GameObject obj = Object.Instantiate(prefab, parent, worldPositionStays);
            objectResolver.InjectGameObject(obj);
            return obj;
        }

        public GameObject Instantiate(
            IObjectResolver objectResolver, 
            GameObject prefab,
            Vector3 position,
            Quaternion rotation)
        {
            GameObject obj = Object.Instantiate(prefab, position, rotation);
            objectResolver.InjectGameObject(obj);
            return obj;
        }

        public GameObject Instantiate(
            IObjectResolver objectResolver, 
            GameObject prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent)
        {
            GameObject obj = Object.Instantiate(prefab, position, rotation, parent);
            objectResolver.InjectGameObject(obj);
            return obj;
        }
    }
}