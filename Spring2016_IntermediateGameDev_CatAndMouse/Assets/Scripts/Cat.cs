using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public Transform mouse;
	public GameObject model1;
	public GameObject model2;
	public GameObject blood;
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (mouse == null){
			
			return;

		}
		else {
			Vector3 directionToMouse = mouse.position - transform.position;

			if (Vector3.Angle(transform.forward, directionToMouse) <= 45f) {
				
				Ray catRay = new Ray(transform.position, directionToMouse);

				RaycastHit catRayHitInfo = new RaycastHit();

				if (Physics.Raycast (catRay, out catRayHitInfo, 100f)){

					
					if (catRayHitInfo.collider.tag == "Mouse"){

						model1.SetActive(false);
						model2.SetActive(true);
						
						if (catRayHitInfo.distance <= 5f){

							GameObject.Destroy(mouse.gameObject);
							blood.SetActive(true);

						} else {
							
							GetComponent<Rigidbody>().AddForce((directionToMouse.normalized) * 1000f);

						}
					} else {
						model1.SetActive(true);
						model2.SetActive(false);
					}
				}
			}
		}
	}
}
