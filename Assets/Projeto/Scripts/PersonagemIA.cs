using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PersonagemIA : MonoBehaviour {

	private Transform target;

	public float velocidade = 500f;
	public float nextWaypointDistance = 1f;

	Path path;
	int currentWaypoint = 0;
	bool fimDoCaminho = false;

	Seeker seeker;
	Rigidbody2D rb;

	private Animator anim;
	private bool movendo;
	private bool calcularPath = true;
	private bool estavaMovendoVertical = false;
	Vector2 ultimoMovimento;
	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		UpdatePath();

		//InvokeRepeating("UpdatePath", 0f, .5f);
	}

	IEnumerator pathCooldown(float t){
		calcularPath = false;
		UpdatePath();
		yield return new WaitForSeconds(t);
		calcularPath = true;
	}

	void UpdatePath(){
			float x = Random.Range(rb.position.x - 20, rb.position.x + 20);
			float y = Random.Range(rb.position.y - 20, rb.position.y + 20);;
			Vector2 pos = new Vector2(x,y);
			seeker.StartPath(rb.position, pos, OnPathComplete);
	}
	
	void OnPathComplete(Path p){
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}
	}
	// Update is called once per frame
	void Update () {
		if(calcularPath){
			float aleatorio = Random.Range(0f, 5f);
			StartCoroutine(pathCooldown(aleatorio));				
		}
		if (path == null)
			return;
		if (currentWaypoint >= path.vectorPath.Count)
		{
			fimDoCaminho = true;
			movendo = false;
			rb.velocity = Vector2.zero;
			
			anim.enabled = false;
			return;
		}
		else
		{
			fimDoCaminho = false;
		}


		Vector2 direcao = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
		//print("path.vectorPath[currentWaypoint]: "+(Vector2)path.vectorPath[currentWaypoint]);
		//print("rb.position: "+rb.position);
		//print("Mathf.Round(1f): "+Mathf.Round(1f));
		//print("direcao: "+direcao);

		//print("direcao x: "+direcao.x);

		//Vector2 forca = direcao * velocidade * Time.deltaTime;
		//print("direcao: "+direcao);
		//print("direcaox: "+direcao.x);
		//print("direcaoy: "+direcao.y);

		float currentMoveSpeed = velocidade * Time.deltaTime;

		float horizontal = Mathf.Round(direcao.x);
		bool movendoHorizontal = Mathf.Abs(horizontal) > 0.5f;

		float vertical = Mathf.Round(direcao.y);
		bool movendoVertical = Mathf.Abs(vertical) > 0.5f;

		movendo = true;

		//print("vertical: "+vertical);
		//print("horizontal: "+horizontal);
		if (movendoVertical && movendoHorizontal && !fimDoCaminho)
		{
			anim.enabled = true;

			if (estavaMovendoVertical)
			{
				rb.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
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
			else
			{
				rb.velocity = new Vector2(0, vertical * currentMoveSpeed);
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
		}
		else if (movendoHorizontal && !fimDoCaminho)
		{
			anim.enabled = true;

			rb.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
			estavaMovendoVertical = false;
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
		else if (movendoVertical && !fimDoCaminho)
		{
			anim.enabled = true;

			rb.velocity = new Vector2(0, vertical * currentMoveSpeed);
			estavaMovendoVertical = true;
			ultimoMovimento = new Vector2(0f, vertical);

			if (vertical > 0  )
			{
				anim.SetTrigger("cima");
			}
			else if (vertical < 0 )
			{
				anim.SetTrigger("baixo");
			}
			
		}
		

		float distancia = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
		if (distancia < nextWaypointDistance)
		{
			currentWaypoint++;
		}
	}
}
