using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFase : MonoBehaviour {

	public GameObject ia1, ia2, ia3, ia4, ia5, ia6, ia7, ia8, ia9;
	public GameObject j1, j2, j3, j4, j5, j6, j7, j8, j9;
	public int personagemSelecionado;

	// Use this for initialization
	void Start () {
		CriaPersonagens();

		//SCORE ZERADO
		PlayerPrefs.SetInt("score", 0);
	}

	void CriaPersonagens(){
		List<GameObject> listaIA = new List<GameObject>();
		listaIA.Add(ia1);
		listaIA.Add(ia3);
		listaIA.Add(ia2);
		listaIA.Add(ia4);
		listaIA.Add(ia5);
		listaIA.Add(ia6);
		listaIA.Add(ia7);
		listaIA.Add(ia8);
		listaIA.Add(ia9);

		personagemSelecionado = PlayerPrefs.GetInt("bandido");
		switch (personagemSelecionado)
		{
			case 1:
				Instantiate(j1, transform.position, transform.rotation);
				Instantiate(ia1, transform.position, transform.rotation);
				Instantiate(ia1, transform.position, transform.rotation);
			break;
			case 2:
				Instantiate(j2, transform.position, transform.rotation);	
				Instantiate(ia2, transform.position, transform.rotation);
				Instantiate(ia2, transform.position, transform.rotation);			
			break;
			case 3:
				Instantiate(j3, transform.position, transform.rotation);
				Instantiate(ia3, transform.position, transform.rotation);
				Instantiate(ia3, transform.position, transform.rotation);
			break;
			case 4:
				Instantiate(j4, transform.position, transform.rotation);
				Instantiate(ia4, transform.position, transform.rotation);
				Instantiate(ia4, transform.position, transform.rotation);
			break;
			case 5:
				Instantiate(j5, transform.position, transform.rotation);
				Instantiate(ia5, transform.position, transform.rotation);
				Instantiate(ia5, transform.position, transform.rotation);
			break;
			case 6:
				Instantiate(j6, transform.position, transform.rotation);
				Instantiate(ia6, transform.position, transform.rotation);
				Instantiate(ia6, transform.position, transform.rotation);
			break;
			case 7:
				Instantiate(j7, transform.position, transform.rotation);
				Instantiate(ia7, transform.position, transform.rotation);
				Instantiate(ia7, transform.position, transform.rotation);
			break;
			case 8:
				Instantiate(j8, transform.position, transform.rotation);
				Instantiate(ia8, transform.position, transform.rotation);
				Instantiate(ia8, transform.position, transform.rotation);
			break;
			case 9:
				Instantiate(j9, transform.position, transform.rotation);
				Instantiate(ia9, transform.position, transform.rotation);
				Instantiate(ia9, transform.position, transform.rotation);
			break;
		}

		for	(int i = 0; i<=8; i++) {
			if (i+1 != personagemSelecionado){
				Instantiate(listaIA[i], transform.position, transform.rotation);
				Instantiate(listaIA[i], transform.position, transform.rotation);
				Instantiate(listaIA[i], transform.position, transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
