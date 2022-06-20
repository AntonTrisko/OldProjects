using System.Collections.Generic;
using System;

namespace com
{
    public class EventManager
    {
        static public string CLICK = "click";
        static public string MOVE = "move";
        static public string VICTORY = "victory";
        static public string GAMEOVER = "gameover";
        static public string DESTROIED = "destroied";
        static public string DAMAGED ="damaged";
        static public string FIRED = "fired";
        static private Dictionary<string, List<Action<EventData>>> _pool = new Dictionary<string, List<Action<EventData>>>();

        static public void AddListener(string eventName, Action<EventData> callback)
        {
            if(_pool.ContainsKey(eventName)) {
                _pool[eventName].Add(callback);
                return;
            }
            List<Action<EventData>> l = new List<Action<EventData>>();
            l.Add(callback);
            _pool.Add(eventName, l);
        }
        static public void RemoveAllEvents()
        {
                _pool.Clear();
        }
        static public void DispatchEvent(string eventName, EventData data)
        {
            if(!_pool.ContainsKey(eventName))
            {
                return;
            }

            List<Action<EventData>> lAction = _pool[eventName];
            for(int i = 0; i < lAction.Count; i++){
                lAction[i](data);
            }
        }

        static public bool RemoveEvent(string eventName, Action<EventData> callback)
        {
            if(!_pool.ContainsKey(eventName))
            {
                return false;
            }
            List<Action<EventData>> lAction = _pool[eventName];
            for(int i = 0; i < lAction.Count; i++) {
                if(lAction[i] == callback){
                    lAction.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}