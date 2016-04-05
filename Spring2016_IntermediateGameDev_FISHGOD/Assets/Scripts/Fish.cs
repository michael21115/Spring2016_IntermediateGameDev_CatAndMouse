using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	// SerializeField exposes variable to Inspector without making it public
	[SerializeField] float speed = 5f;
	public Vector3 destination; // Where the fish is trying to go
	[SerializeField] float stoppingDistance = 1f;

	// Update is called once per frame
	void Update () {
		Debug.DrawLine(transform.position, destination, Color.yellow);
		float distance = Vector3.Distance(destination, transform.position);

		// if position is greater than my stopping distance -- move towards the destination
		if (distance > stoppingDistance){
			transform.position += (destination - transform.position).normalized * Time.deltaTime * speed;
			transform.LookAt(destination);
		}
	}
}
