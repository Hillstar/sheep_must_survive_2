using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsterioid : MonoBehaviour {

    public float speed = 3f;
    public GameObject explosion;
    public float explOffset = 2f;
    public bool ifNotMenu = false;
	
	// Update is called once per frame
	void Update () {

        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            GameManager.isPlayerAlive = false;
        }

        else if (col.gameObject.CompareTag("Floor"))
        {
            Instantiate(explosion, transform.position + Vector3.down * explOffset, Quaternion.identity);
            DontDestroyParticles();
            Destroy(gameObject);
        }
    }

    void DontDestroyParticles()
    {
        Transform PE = transform.Find("Asteroid Trail");
        PE.GetComponent<ParticleSystem>().Stop();
        PE.gameObject.transform.parent = null;
        if (ifNotMenu)
            PE.transform.localScale = new Vector3(1f, 1f, 1f);
        else
            PE.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        Destroy(PE.gameObject, 1.5f); // if particles live for at most 5 secs
    }
}
