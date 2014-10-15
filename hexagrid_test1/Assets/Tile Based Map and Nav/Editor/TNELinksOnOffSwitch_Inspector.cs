// ====================================================================================================================
//
// Created by Leslie Young
// http://www.plyoung.com/ or http://plyoung.wordpress.com/
// ====================================================================================================================

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(TNELinksOnOffSwitch))]
public class TNELinksOnOffSwitch_Inspector : Editor
{

	private static GUIContent GC_SelButton = new GUIContent("#", "View link in Scene");
	private static GUIContent GC_DelButton = new GUIContent("X", "Delete Link info");
	private int idx = -1;

	public override void OnInspectorGUI()
	{
		TNELinksOnOffSwitch t = target as TNELinksOnOffSwitch;
		t.mask = (TileNode.TileType)EditorGUILayout.EnumMaskField("Mask", t.mask);

		GUILayout.Label("Links", EditorStyles.largeLabel);
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(55);
		GUILayout.Label("On", GUILayout.Width(25));
		GUILayout.Label("Link with");
		EditorGUILayout.EndHorizontal();

		int del = -1;
		for (int i = 0; i < t.linkStates.Count; i++)
		{
			EditorGUILayout.BeginHorizontal();

			if (GUILayout.Button(GC_SelButton, GUILayout.Width(25)))
			{
				idx = i;
			}
			if (GUILayout.Button(GC_DelButton, GUILayout.Width(25)))
			{
				del = i;
			}
			t.linkStates[i].isOn = EditorGUILayout.Toggle(t.linkStates[i].isOn, GUILayout.Width(20));
			t.linkStates[i].neighbour = (TileNode)EditorGUILayout.ObjectField(t.linkStates[i].neighbour, typeof(TileNode), true);

			EditorGUILayout.EndHorizontal();
		}

		if (del >= 0)
		{
			if (idx == del) idx = -1;
			t.linkStates.RemoveAt(del);
			GUI.changed = true;
		}

		if (GUI.changed) EditorUtility.SetDirty(target);
	}

	protected void OnSceneGUI()
	{
		if (idx < 0) return;
		TNELinksOnOffSwitch t1 = target as TNELinksOnOffSwitch;
		TileNode t2 = t1.linkStates[idx].neighbour;
		if (t2 == null) return;

		Handles.color = t1.linkStates[idx].isOn ? Color.green : Color.red;
		Handles.DrawAAPolyLine(20f, t1.transform.position, t2.transform.position);
	}

	// ====================================================================================================================
}
