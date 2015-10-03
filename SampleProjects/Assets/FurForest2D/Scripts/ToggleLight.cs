using UnityEngine;
using System.Collections;

public class ToggleLight : MonoBehaviour {
	
	public GameObject theLight = null;
	public ParticleSystem Lightparticles;

	void Start(){

		theLight.GetComponent<Light>().enabled = false;
		Lightparticles.GetComponent<ParticleSystem> ().enableEmission = false;
	}

	void OnTriggerEnter2D(Collider2D lightsOn)
	{

		if (theLight != null && theLight.GetComponent<Light>() != null && lightsOn.gameObject.tag =="FurFly")
		{
				theLight.GetComponent<Light>().enabled = !theLight.GetComponent<Light>().enabled;
				Lightparticles.GetComponent<ParticleSystem> ().enableEmission = true;

				Invoke("LvlChange2",2f);

		}
	}

		void LvlChange2()
		{
			Application.LoadLevel("Dusk");
		}
	



}
