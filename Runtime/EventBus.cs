using System;
using System.Collections.Generic;

namespace UnityEventBus
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, List<Delegate>> Subscribers = new();

        public static void Subscribe<T>(Action<T> callback) where T : IEvent
        {
            var type = typeof(T);
            if (!Subscribers.ContainsKey(type))
                Subscribers[type] = new List<Delegate>();

            Subscribers[type].Add(callback);
        }

        public static void Unsubscribe<T>(Action<T> callback) where T : IEvent
        {
            var type = typeof(T);
            if (Subscribers.TryGetValue(type, out var list))
            {
                list.Remove(callback);
                if (list.Count == 0)
                    Subscribers.Remove(type);
            }
        }

        public static void Raise<T>(T eventData) where T : IEvent
        {
            var type = typeof(T);
            if (Subscribers.TryGetValue(type, out var list))
            {
                foreach (var callback in list.ToArray())
                {
                    ((Action<T>)callback)?.Invoke(eventData);
                }
            }
            else
                UnityEngine.Debug.LogWarning($"No subscribers found for {type.Name}");
        }
    }
}