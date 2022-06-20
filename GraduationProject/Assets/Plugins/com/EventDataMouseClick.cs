using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace com
{
    public class EventDataMouseClick : EventData
    {
        private string _data;
        private int _myInt;

        public EventDataMouseClick(string data, int myInt) : base(data)
        {
            _data = data;
            _myInt = myInt;
        }

        public object Data {
            get {
                return _data;
            }
        }

        public int MyInt{
            get {
                return _myInt;
            }
        }
    }
}