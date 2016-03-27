using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Transform cat;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToCat = cat.position - transform.position;

		if (Vector3.Angle(transform.forward, directionToCat) <= 45f) {
			
			Ray mouseRay = new Ray(transform.position, directionToCat);

			RaycastHit mouseRayHitInfo = new RaycastHit();

			if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 100f)){

				if (mouseRayHitInfo.collider.tag == "Cat"){

					GetComponent<Rigidbody>().AddForce((-directionToCat.normalized) * 1000f);

				}
			}
		}
	}
}
