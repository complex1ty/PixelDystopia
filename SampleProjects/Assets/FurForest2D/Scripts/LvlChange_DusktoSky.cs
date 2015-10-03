using UnityEngine;
using System.Collections;

public class LvlChange_DusktoSky : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision2D)
	{

		if (collision2D.gameObject.tag =="Player")
		Invoke("LvlChange",.2f);
	}

	void LvlChange()
	{
		Application.LoadLevel("SkyClouds");
	}

}
