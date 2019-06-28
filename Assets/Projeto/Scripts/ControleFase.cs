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

		UpdateCollisionLayerMatrix();
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

	//Script que faz o Layer Collision Matrix nao ignorar colliders com trigger
	public static void UpdateCollisionLayerMatrix()
	{
		List<Tuple<Collider2D, Collider2D>> collidersToUpdate = new List<Tuple<Collider2D, Collider2D>>();
		Collider2D[] colliders = FindObjectsOfType(typeof(Collider2D)) as Collider2D[];
		if (colliders == null) return;
	
		foreach (Collider2D colliderA in colliders)
		{
			foreach (Collider2D colliderB in colliders)
			{
				if (colliderA.gameObject == colliderB.gameObject) continue;
						
				if (Physics2D.GetIgnoreLayerCollision(colliderA.gameObject.layer, colliderB.gameObject.layer))
				{
					collidersToUpdate.Add(new Tuple<Collider2D, Collider2D>(colliderA, colliderB));
				}
			}
		}
	
		foreach (Tuple<Collider2D, Collider2D> tuple in collidersToUpdate)
		{
			Physics2D.IgnoreLayerCollision(tuple.ItemA.gameObject.layer, tuple.ItemB.gameObject.layer, false);
			if (!tuple.ItemA.isTrigger && !tuple.ItemB.isTrigger)
			{
				Physics2D.IgnoreCollision(tuple.ItemA, tuple.ItemB, true);
			}
		}
	}
}

public class Tuple<T, U>
{
    public T ItemA { get; set; }
    public U ItemB { get; set; }

    public Tuple(T itemA, U itemB)
    {
        ItemA = itemA;
        ItemB = itemB;
    }
}

