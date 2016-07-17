﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject 
{
	[MenuItem("Assets/Create/Menu Object")]
	public static void CreateMyMenuObject()
	{
		MenuObject asset = ScriptableObject.CreateInstance<MenuObject>();

		AssetDatabase.CreateAsset(asset, "Assets/MenuObject.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}