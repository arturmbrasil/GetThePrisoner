using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour {

	int valor;
	bool podePegar = false;
	// Use this for initialization
	void Start () {
		valor = Random.Range(1, 100);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q) && podePegar){
			Pegar();
		}
	}
	
	void Pegar(){
		//Soma valor do item na pontuacao do bandido
		int score = PlayerPrefs.GetInt("score");
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Bandido")
		{
			podePegar = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bandido")
		{
			podePegar = false;
		}
	}

	
}
