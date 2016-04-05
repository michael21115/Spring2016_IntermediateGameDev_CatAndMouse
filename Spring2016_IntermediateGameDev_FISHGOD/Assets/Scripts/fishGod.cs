using UnityEngine;
using System.Collections;

// YOU NEED THIS LINE TO USE LISTS
using System.Collections.Generic;

public class fishGod : MonoBehaviour {

	// The Job of the FishGod:
	// - create fish
	// - command fish

	public Fish fishPrefab; // assign in inspector

	List<Fish> listOfFish = new List<Fish>();

	void MoveFish (Vector3 pointInSpace) {
		foreach (Fish thisFish in listOfFish){
			thisFish.destination = pointInSpace;
		}
	}

	void Start () {
		// FishSpawner
		while (listOfFish.Count < 1000){
			Fish newFish = (Fish)Instantiate(fishPrefab, Random.insideUnitSphere * 10f, Random.rotation);
			listOfFish.Add(newFish); // Add a new fish to listOfFish
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			// DO THIS TO EVERYTHING OF X TYPE IN X PLACE
			foreach (Fish thisFish in listOfFish){
				thisFish.destination = Random.insideUnitSphere * 10f;
			}
		}

		// Raycast based on mouse location
		Ray clickedSpot = Camera.main.ScreenPointToRay(Input.mousePosition);
		// initialize the info
		RaycastHit rayHitInfo = new RaycastHit();
		// if clicked, shoot raycast
		if (Input.GetMouseButton(0) && Physics.Raycast(clickedSpot, out rayHitInfo, 1000f)){
			MoveFish(rayHitInfo.point);
		}
	}
}
