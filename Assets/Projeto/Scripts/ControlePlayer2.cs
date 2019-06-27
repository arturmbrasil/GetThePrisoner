using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer2 : MonoBehaviour {

private Rigidbody2D rb;
    public float velocidade;
	private Animator anim;
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
		float currentMoveSpeed = velocidade * Time.deltaTime;

		float horizontal = Input.GetAxisRaw("p2Horizontal");
		bool movendoHorizontal = Mathf.Abs(horizontal) > 0.5f;

		float vertical = Input.GetAxisRaw("p2Vertical");
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
				else if (horizontal < 0 )
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

			if (horizontal > 0 )
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
			
			if (vertical > 0 )
			{
				anim.SetTrigger("cima");
			}
			else if (vertical < 0 )
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

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        
    }
    public void addScore(int pontuacao)
    {
        
    }
}
