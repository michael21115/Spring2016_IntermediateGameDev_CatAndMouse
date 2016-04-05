using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreePlanter : MonoBehaviour {

	public Transform Tree1prefab;
	public Transform Tree2prefab;
	List<Transform> listOfTrees = new List<Transform>();
	
	// Update is called once per frame
	void Update () {
		Ray planter = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHitInfo = new RaycastHit();

		if (Physics.Raycast (planter, out rayHitInfo, 1000f) && rayHitInfo.transform.tag == "plantingLayer"){
			if (Input.GetMouseButtonDown(0)){
				Transform newTree = (Transform)Instantiate(Tree1prefab, rayHitInfo.point + new Vector3 (0f, 3f, 0f), Quaternion.identity);
				listOfTrees.Add(newTree);
			} 
			else if (Input.GetMouseButtonDown(1)){
				Transform newTree = (Transform)Instantiate(Tree2prefab, rayHitInfo.point + new Vector3 (0f, 3f, 0f), Quaternion.identity);
				listOfTrees.Add(newTree);
			} 
			else {
				return;
			}
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			foreach (Transform thisTree in listOfTrees){
				thisTree.localScale *= 0.9f;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			foreach (Transform thisTree in listOfTrees){
				thisTree.localScale *= 1.1f;
			}
		}
	}
}
