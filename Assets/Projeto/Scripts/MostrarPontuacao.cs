using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPontuacao : MonoBehaviour {

	public Text textoPontos;
	// Use this for initialization
	void Start () {
		textoPontos.text = PlayerPrefs.GetInt("score")+"";	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
