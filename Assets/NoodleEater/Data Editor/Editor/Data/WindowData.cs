﻿using System.Collections.Generic;
using UnityEngine;

namespace NoodleEater.DataEditor.Data
{

    public class WindowData
    {
        private string[] _dataType = System.Enum.GetNames(typeof(ValueType));
        private string[] _boolData = new string[] { "true", "false" };
        private int _currentType = 0;
        private int _boolValue = 0;
        private int _fieldCount = 1;

        private List<FieldValue> _fields = new List<FieldValue>();

        public string[] DataType { get => _dataType; }
        public string[] BoolData { get => _boolData; }
        public int CurrentType { get => _currentType; set => _currentType = value; }
        public int BoolValue { get => _boolValue; set => _boolValue = value; }
        public int FieldCount { get => _fieldCount; set => _fieldCount = value; }
        public string ClassName { get; set; }
        public List<FieldValue> Fields { get => _fields; }

        public void AddField()
        {
            Fields.Add(new FieldValue());
        }
    }
}
