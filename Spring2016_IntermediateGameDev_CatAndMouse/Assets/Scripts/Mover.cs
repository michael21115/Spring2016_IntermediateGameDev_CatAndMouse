using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float moveSpeed;
	public AudioSource bumpSound;
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed + Physics.gravity;

		Ray moveRay = new Ray(transform.position, transform.forward);
		Debug.DrawRay(transform.position, transform.forward * 5f, Color.yellow);

		if (Physics.SphereCast(moveRay, 0.2f, 2f)){

			float randomizer = Random.value;

			if (randomizer <= .5f){
				transform.Rotate(0f, 90f, 0f);
			}
			else {
				transform.Rotate(0f, -90f, 0f);
				bumpSound.Play();
			}
		}
	}
}