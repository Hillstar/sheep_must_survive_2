using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour 
{
    public float speed = 3f;
    public GameObject explosion;
    public float explOffset = 2f;
    public bool ifNotMenu = false;
	
	// Update is called once per frame
	private void Update () 
    {
        transform.Translate(transform.up * (speed * Time.deltaTime), Space.World);
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

    private void DontDestroyParticles()
    {
        var pe = transform.Find("Asteroid Trail");
        pe.GetComponent<ParticleSystem>().Stop();
        pe.gameObject.transform.parent = null;
        
        if (ifNotMenu)
            pe.transform.localScale = new Vector3(1f, 1f, 1f);
        else
            pe.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        
        Destroy(pe.gameObject, 1.5f); // if particles live for at most 5 secs
    }
}
