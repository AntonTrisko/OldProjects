using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace com
{
    public class EventData
    {
        private object _data;

        public EventData(object data) 
        {
            _data = data;
        }
        


        public object Data{
            get {
                return _data;
            }
        }
    }
}