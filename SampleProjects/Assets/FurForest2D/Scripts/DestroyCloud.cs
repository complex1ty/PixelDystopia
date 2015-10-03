using UnityEngine;
using System.Collections;

public class DestroyCloud : MonoBehaviour {

	// Use this for initialization
	void Start(){

		Invoke("DestroyIt",0.9f);
	}

	void DestroyIt(){
		Destroy(gameObject);}

	// Update is called once per frame
	void Update () {
	
	}
}
