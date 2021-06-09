using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DictionaryInEditor))]
public class DictionaryCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        {
            if (((DictionaryInEditor)target).modifyValues)
            {
                if(GUILayout.Button("Save Changes"))
                {
                    ((DictionaryInEditor)target).DeserializationDictionary();
                }
            }
        }
    }
}
