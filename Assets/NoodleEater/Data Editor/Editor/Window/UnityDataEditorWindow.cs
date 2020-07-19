﻿using NoodleEater.DataEditor.Data;
using UnityEditor;
using UnityEngine;

namespace NoodleEater.DataEditor
{

    public class UnityDataEditorWindow : EditorWindow
    {
        private WindowData _data = new WindowData();
        private WindowUIDrawer _drawer = new WindowUIDrawer();

        [MenuItem("Unity-Data-Editor/DataWindow")]
        private static void ShowWindow()
        {
            var window = GetWindow<UnityDataEditorWindow>();
            window.titleContent = new GUIContent("DataWindow");
            window.Show();
        }

        private void OnEnable()
        {
            _data.Init();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            _drawer.DrawHorizontalLabel("Field", "Type", "Value");
            DrawField();
            EditorGUILayout.EndVertical();
            _drawer.DrawButton("Add New Field", () =>
            {
                _data.FieldCount++;
                _data.Init();
            });
            
            _drawer.DrawButton("Save", () => {
                Debug.Log("Save");
                _data.Fields.ForEach((item) => Debug.Log(item.ToString()));
            });
        }

        private void DrawField()
        {
            EditorGUILayout.BeginVertical();
            for (int i = 0; i < _data.FieldCount; i++)
            {
                EditorGUILayout.BeginHorizontal();

                var field = _data.Fields[i];
                field.fieldName = EditorGUILayout.TextField(field.fieldName);

                _data.CurrentType = EditorGUILayout.Popup(_data.CurrentType, _data.DataType);
                field.type = _data.DataType[_data.CurrentType];
                
                var value = string.Empty;
                if (_data.DataType[_data.CurrentType] == "bool")
                {
                    _data.BoolValue = EditorGUILayout.Popup(_data.BoolValue, _data.BoolData, GUILayout.Width(position.width - 200));
                    field.value = _data.BoolData.ToString();
                }
                else
                {
                    field.value = EditorGUILayout.TextField(field.value, GUILayout.Width(position.width - 200));
                }

                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
    }
}