using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saida : MonoBehaviour {

	bool podeSair = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q) && podeSair){
			Sair();
		}
	}

	void Sair(){
		SceneManager.LoadScene("BandidoFugiu");	
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Bandido")
		{
			podeSair = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bandido")
		{
			podeSair = false;
		}
	}
}
