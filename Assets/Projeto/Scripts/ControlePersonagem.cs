using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlePersonagem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;
    private Vector3 change;
    float timerFase = 0;
    public int score = 0;
	private Animator anim;
	private string ultimaAnimacao;
	private bool movendo;
	private bool estavaMovendoVertical = false, estavaMovendoHorizontal = false;
	Vector2 ultimoMovimento;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		/* 
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		//Parado
		if(x == 0 && y == 0)
		{
			rb.velocity = new Vector2 (velocidade * x, velocidade * y);
			anim.enabled = false;
		}
		//Esquerda
		else if(x < 0)
		{
			anim.enabled = true;
			ultimaAnimacao = "esquerda";
			anim.SetTrigger("esquerda");
			
			if (ultimaAnimacao == "esquerda")
			{
				rb.velocity = new Vector2 (velocidade * x, 0);			
			}
		}
		//Direita
		else if (x > 0)
		{
			anim.enabled = true;
			ultimaAnimacao = "direita";
			anim.SetTrigger("direita");
			
			if (ultimaAnimacao == "direita"){
				rb.velocity = new Vector2 (velocidade * x, 0);
			}
		}
		//Baixo
		else if(y < 0)
		{
			anim.enabled = true;
			ultimaAnimacao = "baixo";
			anim.SetTrigger("baixo");

			if (ultimaAnimacao == "baixo"){
				rb.velocity = new Vector2 (0, velocidade * y);
			}
		}
		//Cima
		else if(y > 0)
		{
			anim.enabled = true;
			ultimaAnimacao = "cima";
			anim.SetTrigger("cima");

			if (ultimaAnimacao == "cima"){
				rb.velocity = new Vector2 (0, velocidade * y);
			}
		}
		*/

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

				if (horizontal > 0 && ultimaAnimacao != "direita")
				{
					ultimaAnimacao = "direita";
					anim.SetTrigger("direita");
				}
				else if (horizontal < 0 && ultimaAnimacao != "esquerda")
				{
					ultimaAnimacao = "esquerda";
					anim.SetTrigger("esquerda");
				}
			}
			else
			{
				rb.velocity = new Vector2(0, vertical * currentMoveSpeed);
				ultimoMovimento = new Vector2(0f, vertical);

				if (vertical > 0 && ultimaAnimacao != "cima")
				{
					ultimaAnimacao = "cima";
					anim.SetTrigger("cima");
				}
				else if (vertical < 0 && ultimaAnimacao != "baixo")
				{
					ultimaAnimacao = "baixo";
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

			if (horizontal > 0 && ultimaAnimacao != "direita")
			{
				ultimaAnimacao = "direita";
				anim.SetTrigger("direita");
			}
			else if (horizontal < 0 && ultimaAnimacao != "esquerda")
			{
				ultimaAnimacao = "esquerda";
				anim.SetTrigger("esquerda");
			}
		}
		else if (movendoVertical)
		{
			anim.enabled = true;

			rb.velocity = new Vector2(0, vertical * currentMoveSpeed);
			estavaMovendoVertical = true;
			ultimoMovimento = new Vector2(0f, vertical);
			
			if (vertical > 0 && ultimaAnimacao != "cima")
			{
				ultimaAnimacao = "cima";
				anim.SetTrigger("cima");
			}
			else if (vertical < 0 && ultimaAnimacao != "baixo")
			{
				ultimaAnimacao = "baixo";
				anim.SetTrigger("baixo");
			}
		}
		else
		{
			movendo = false;
			rb.velocity = Vector2.zero;
			
			anim.enabled = false;
			ultimaAnimacao = "parado";
		}
        timerFase += Time.deltaTime; // acréscimo de 1 a cada segundo na variável timer

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        
    }
    public void addScore(int pontuacao)
    {
        
    }
}
