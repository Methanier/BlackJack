using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Card))]
public class CardEditor : Editor
{
    Card cardTarget;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        cardTarget = target as Card;
        base.OnInspectorGUI();

        if(GUI.changed)
        {
            cardTarget.UpdateName();
        }
    }
}
