using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlerContagemRegressiva : MonoBehaviour {

	public float _tempoInicial = 120;
	public Text _contadorRegressivo;

	public string tempoZerado;

	// Use this for initialization
	void Start () {

		_contadorRegressivo.text = _tempoInicial.ToString();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(_tempoInicial >= 0){

			_tempoInicial -= Time.deltaTime;
			_contadorRegressivo.text = Mathf.Round(_tempoInicial).ToString();

			if(_tempoInicial <= 0){
				SceneManager.LoadScene(tempoZerado);
			}

		}
		
	}
}
