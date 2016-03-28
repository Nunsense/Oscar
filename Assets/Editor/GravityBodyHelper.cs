using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GravityBody))]
public class GravityBodyHelper : Editor {
	public GravityBody body;

	public void Awake() {
		body = (GravityBody)target;
	}

	public void Start() {
	}

	public void OnEnable() {
		SceneView.onSceneGUIDelegate = GridUpdate;
	}

	public void OnDisable() {
		SceneView.onSceneGUIDelegate -= GridUpdate;
	}
	//
	//	public override void OnInspectorGUI() {
	////		GUILayout.BeginHorizontal();
	////		GUILayout.Label("Level");
	////		changeLevel = EditorGUILayout.Popup(map.grid.level, levelNames, GUILayout.Width(80));
	////		if (map.grid.level != changeLevel) { 
	////			if (EditorUtility.DisplayDialog("Change level", "Do you want to save current level first?", "Fuck yeah!", "Fuck no!")) {
	////				map.gameSave.SaveData(ToLevelData());
	////				Debug.Log("Level Saved");
	////			}
	////			if (changeLevel == levelNames.Length - 1) {
	////				map.gameSave.NewLevel();
	////				LoadLevelNames();
	////			}
	////			map.LoadLevel(changeLevel);
	////
	////			Debug.Log("Level " + changeLevel + " loaded");
	////		} 
	////
	////		if (GUILayout.Button("Save", GUILayout.Width(60))) { 
	////			map.gameSave.SaveData(ToLevelData());
	////			Debug.Log("Level Saved");
	////		} 
	////		GUILayout.EndHorizontal();
	////
	////		GUILayout.BeginHorizontal();
	////		GUILayout.Label("Move Level");
	////		moveToLevel = EditorGUILayout.Popup(moveToLevel, levelNamesMoveTo, GUILayout.Width(80));
	////		if (GUILayout.Button("Move", GUILayout.Width(60))) {
	////			if (EditorUtility.DisplayDialog("Change level", "Do you want to save current level first?", "Fuck yeah!", "Fuck no!")) {
	////				map.gameSave.SaveData(ToLevelData());
	////				Debug.Log("Level Saved");
	////			}
	////			map.gameSave.ChangeLevel(moveToLevel); 
	////			Debug.Log("Level " + map.grid.level + " moved to " + moveToLevel);
	////		} 
	////		GUILayout.EndHorizontal();
	////
	////		GUILayout.BeginHorizontal();
	////		GUILayout.Label("Grid W, H, D");
	////		tempGridW = EditorGUILayout.IntField(tempGridW, GUILayout.Width(40));
	////		tempGridH = EditorGUILayout.IntField(tempGridH, GUILayout.Width(40));
	////		tempGridD = EditorGUILayout.IntField(tempGridD, GUILayout.Width(40));
	////		if (GUILayout.Button("Create", GUILayout.Width(80))) {
	////			Element[][][] tempGrid = new Element[tempGridW][][];
	////
	////			for (int i = 0; i < tempGridW && i < map.grid.w; i++) {
	////				tempGrid[i] = new Element[tempGridH][];
	////				for (int j = 0; j < tempGridH && j < map.grid.d; j++) {
	////					tempGrid[i][j] = new Element[tempGridD];
	////					for (int k = 0; j < tempGridD && k < map.grid.h; k++) {
	////						tempGrid[i][j][k] = map.grid.Get(i, j, k);
	////					}
	////				}
	////			}
	////
	////			for (int i = 0; i < map.grid.w; i++) {
	////				for (int j = 0; j < map.grid.d; j++) {
	////					for (int k = 0; k < map.grid.h; k++) {
	////						map.grid.Set(i, j, k, null);
	////					}
	////				}
	////			}
	////			map.grid.elements = tempGrid;
	////			map.grid.w = tempGridW;
	////			map.grid.d = tempGridH;
	////			map.grid.h = tempGridD;
	////			EditorUtility.SetDirty(map);
	////		}
	////		GUILayout.EndHorizontal();
	////
	////		if (GUILayout.Button("Clear")) {
	////			for (int i = 0; i < map.grid.w; i++) {
	////				for (int j = 0; j < map.grid.d; j++) {
	////					for (int k = 0; k < map.grid.h; k++) {
	////						if (map.grid.Get(i, j, k)) {
	////							GameObject.DestroyImmediate(map.grid.Get(i, j, k).gameObject);
	////						}
	////						map.grid.Set(i, j, k, null);
	////					}
	////				}
	////			}
	////			map.grid.elements = new Element[map.grid.w][][];
	////			for (int i = 0; i < map.grid.elements.Length; i++) {
	////				map.grid.elements[i] = new Element[map.grid.d][];
	////				for (int j = 0; j < map.grid.d; j++) {
	////					map.grid.elements[i][j] = new Element[map.grid.h];
	////				}
	////			}
	////			EditorUtility.SetDirty(map);
	////		}
	////		DrawDefaultInspector();
	////
	////		if (GUILayout.Button("Fire")) {
	////			changeSelected(map.firePrefav);
	////		}
	////		if (GUILayout.Button("Water")) {
	////			changeSelected(map.waterPrefav);
	////		}
	////		if (GUILayout.Button("Plant")) {
	////			changeSelected(map.plantPrefav);
	////		}
	////		if (GUILayout.Button("Stone")) {
	////			changeSelected(map.stonePrefav);
	////		}
	////		if (GUILayout.Button("Lighting")) {
	////			changeSelected(map.lightingPrefav);
	////		}
	////		if (GUILayout.Button("None")) {
	////			changeSelected(null);
	////		}
	//	}
	//
	void GridUpdate(SceneView sceneview) {
		if (Event.current.functionKey) {
			Vector3 gravityUp = (body.transform.position - body.gravity.transform.position) + body.transform.position;
			Vector3 bodyUp = body.transform.up;

			Quaternion rot = Quaternion.FromToRotation(bodyUp, gravityUp) * body.transform.rotation;
			body.transform.rotation = Quaternion.Slerp(body.transform.rotation, rot, 20f * Time.deltaTime);
		}
	}
}
