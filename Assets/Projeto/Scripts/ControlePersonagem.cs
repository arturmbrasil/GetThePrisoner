using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlePersonagem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;
    float timerFase = 0;
	private Animator anim;
	private bool movendo;
	private bool estavaMovendoVertical = false;
	Vector2 ultimoMovimento;
	bool prenderBandido = false;
	bool prenderIA = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

		float currentMoveSpeed = velocidade * Time.deltaTime;

		float horizontal = Input.GetAxisRaw("Horizontal");
		bool movendoHorizontal = Mathf.Abs(horizontal) > 0.5f;

		float vertical = Input.GetAxisRaw("Vertical");
		bool movendoVertical = Mathf.Abs(vertical) > 0.5f;

		movendo = true;

		if (movendoVertical && movendoHorizontal)
		{
			anim.enabled = true;

			if (estavaMovendoVertical)
			{
				rb.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
				ultimoMovimento = new Vector2(horizontal, 0f);

				if (horizontal > 0)
				{
					anim.SetTrigger("direita");
				}
				else if (horizontal < 0)
				{
					anim.SetTrigger("esquerda");
				}
			}
			else
			{
				rb.velocity = new Vector2(0, vertical * currentMoveSpeed);
				ultimoMovimento = new Vector2(0f, vertical);

				if (vertical > 0)
				{
					anim.SetTrigger("cima");
				}
				else if (vertical < 0)
				{
					anim.SetTrigger("baixo");
				}
			}
		}
		else if (movendoHorizontal)
		{
			anim.enabled = true;

			rb.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
			estavaMovendoVertical = false;
			ultimoMovimento = new Vector2(horizontal, 0f);

			if (horizontal > 0)
			{
				anim.SetTrigger("direita");
			}
			else if (horizontal < 0)
			{
				anim.SetTrigger("esquerda");
			}
		}
		else if (movendoVertical)
		{
			anim.enabled = true;

			rb.velocity = new Vector2(0, vertical * currentMoveSpeed);
			estavaMovendoVertical = true;
			ultimoMovimento = new Vector2(0f, vertical);
			
			if (vertical > 0)
			{
				anim.SetTrigger("cima");
			}
			else if (vertical < 0)
			{
				anim.SetTrigger("baixo");
			}
		}
		else
		{
			movendo = false;
			rb.velocity = Vector2.zero;
			
			anim.enabled = false;
		}
        timerFase += Time.deltaTime; // acréscimo de 1 a cada segundo na variável timer

		if (Input.GetKeyDown(KeyCode.RightShift)){
			print("clicou shift");
			print("prender bandido:" + prenderBandido);
			print("prender ia:" + prenderIA);

			if (prenderBandido)
			{
				SceneManager.LoadScene("CapturaBandido");
			}
			else if (prenderIA)
			{
				int score = PlayerPrefs.GetInt("score");
				score = score + 100; //bandido ganha 100 pontos de bonus
				PlayerPrefs.SetInt("score", score);
				SceneManager.LoadScene("PrendeuInocente");
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Bandido")
		{

			prenderBandido = true;
			print("prender bandido!!!!!!!!!!!!!!!!!!!!!!!!!!:" + prenderBandido);
		}
		if (other.tag == "IA"){
			prenderIA = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bandido")
		{
			prenderBandido = false;
		}
		if (other.tag == "IA"){
			prenderIA = false;
		}
	}

}
