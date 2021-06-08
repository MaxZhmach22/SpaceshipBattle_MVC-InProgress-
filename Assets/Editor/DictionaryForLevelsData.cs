using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Temporary))]
public class DictionaryForLevelsData : Editor
{
    private Dictionary<string, int> _dictionaryEditor;
    public override void OnInspectorGUI()
    {
        _dictionaryEditor = new Dictionary<string, int>();
        Temporary myLdExampleTemporary = (Temporary) target;
        _dictionaryEditor = myLdExampleTemporary.dictionary;
        if (_dictionaryEditor != null)
        {
            foreach (KeyValuePair<string,int>keyValuePair in _dictionaryEditor)
            {
                EditorGUILayout.IntField(keyValuePair.Key.ToString(), keyValuePair.Value);
            }
        }

        DrawDefaultInspector();
    }
}
