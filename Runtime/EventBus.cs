using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilliotGames
{
    public class EventBus
    {
        private readonly Dictionary<string, Delegate> _eventDict = new();

        public void RegisterEvent(string key, Action @event) {
            if (_eventDict.TryGetValue(key, out var existing))
                _eventDict[key] = Delegate.Combine(existing, @event);
            else
                _eventDict[key] = @event;
        }
        public void RegisterEvent<T1>(string key, Action<T1> @event) {
            if (_eventDict.TryGetValue(key, out var existing))
                _eventDict[key] = Delegate.Combine(existing, @event);
            else
                _eventDict[key] = @event;
        }
        public void RegisterEvent<T1, T2>(string key, Action<T1, T2> @event) {
            if (_eventDict.TryGetValue(key, out var existing))
                _eventDict[key] = Delegate.Combine(existing, @event);
            else
                _eventDict[key] = @event;
        }
        public void RegisterEvent<T1, T2, T3>(string key, Action<T1, T2, T3> @event) {
            if (_eventDict.TryGetValue(key, out var existing))
                _eventDict[key] = Delegate.Combine(existing, @event);
            else
                _eventDict[key] = @event;
        }


        public void UnregisterEvent(string key, Action @event)
            => _eventDict[key] = Delegate.Remove(_eventDict[key], @event);
        public void UnregisterEvent<T1>(string key, Action<T1> @event)
            => _eventDict[key] = Delegate.Remove(_eventDict[key], @event);
        public void UnregisterEvent<T1, T2>(string key, Action<T1, T2> @event)
            => _eventDict[key] = Delegate.Remove(_eventDict[key], @event);
        public void UnregisterEvent<T1, T2, T3>(string key, Action<T1, T2, T3> @event)
            => _eventDict[key] = Delegate.Remove(_eventDict[key], @event);


        public void Invoke(string key)
            => (_eventDict.GetValueOrDefault(key) as Action)?.Invoke();
        public void Invoke<T1>(string key, T1 arg1)
            => (_eventDict.GetValueOrDefault(key) as Action<T1>)?.Invoke(arg1);
        public void Invoke<T1, T2>(string key, T1 arg1, T2 arg2)
            => (_eventDict.GetValueOrDefault(key) as Action<T1, T2>)?.Invoke(arg1, arg2);
        public void Invoke<T1, T2, T3>(string key, T1 arg1, T2 arg2, T3 arg3)
            => (_eventDict.GetValueOrDefault(key) as Action<T1, T2, T3>)?.Invoke(arg1, arg2, arg3);
    }
}