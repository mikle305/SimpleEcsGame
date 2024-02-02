using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Services.Factories
{
    public class ObjectActivator
    {
        private readonly IObjectResolver _objectResolver;

        
        public ObjectActivator(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public object Resolve(Type objectType, bool tryManually = false)
        {
            object resolved = null;
            try
            {
                resolved = _objectResolver.Resolve(objectType);
            }
            catch
            {
                // ignored
            }

            if (resolved == null && tryManually)
                return Activator.CreateInstance(objectType);

            return resolved;
        }        
        
        public T Resolve<T>(bool tryManually = false) where T : class
        {
            T resolved = null;
            try
            {
                resolved = _objectResolver.Resolve<T>();
            }
            catch
            {
                // ignored
            }

            if (resolved == null && tryManually)
                return Activator.CreateInstance<T>();

            return resolved;
        }
        
        public T Instantiate<T>(T prefab)
            where T : Component
        {
            T component = Object.Instantiate(prefab);
            _objectResolver.InjectGameObject(component.gameObject);
            return component;
        }

        public T Instantiate<T>(
            T prefab, 
            Transform parent, 
            bool worldPositionStays = false)
            where T : Component
        {
            T component = Object.Instantiate(prefab, parent, worldPositionStays);
            _objectResolver.InjectGameObject(component.gameObject);
            return component;
        }

        public T Instantiate<T>(
            T prefab,
            Vector3 position,
            Quaternion rotation)
            where T : Component
        {
            T component = Object.Instantiate(prefab, position, rotation);
            _objectResolver.InjectGameObject(component.gameObject);
            return component;
        }

        public T Instantiate<T>(
            T prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent)
            where T : Component
        {
            T component = Object.Instantiate(prefab, position, rotation, parent);
            _objectResolver.InjectGameObject(component.gameObject);
            return component;
        }
        
        public GameObject Instantiate(GameObject prefab)
        {
            GameObject obj = Object.Instantiate(prefab);
            _objectResolver.InjectGameObject(obj);
            return obj;
        }

        public GameObject Instantiate(
            GameObject prefab, 
            Transform parent, 
            bool worldPositionStays = false)
        {
            GameObject obj = Object.Instantiate(prefab, parent, worldPositionStays);
            _objectResolver.InjectGameObject(obj);
            return obj;
        }

        public GameObject Instantiate(
            GameObject prefab,
            Vector3 position,
            Quaternion rotation)
        {
            GameObject obj = Object.Instantiate(prefab, position, rotation);
            _objectResolver.InjectGameObject(obj);
            return obj;
        }

        public GameObject Instantiate(
            GameObject prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent)
        {
            GameObject obj = Object.Instantiate(prefab, position, rotation, parent);
            _objectResolver.InjectGameObject(obj);
            return obj;
        }
    }
}