using UnityEngine;
using System.Collections;

public class LvlChange_Sky_Forest : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D collision2D)
	{
		if (collision2D.gameObject.tag =="Player")
		Invoke("LvlChange",.5f);
	}

	void LvlChange(){

		Application.LoadLevel("FurForest");
	}

}
