using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public float noteSpeed;

    public ParticleSystem collectEffect;

    private bool move = true;

    public SpriteRenderer sprite;
    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {

        sprite = transform.GetComponent<SpriteRenderer>();
        rBody = transform.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (move)
            rBody.velocity = new Vector2(0, -noteSpeed);

        else
            rBody.velocity = Vector2.zero;
	}


    public void Collect()
    {
        move = false;
        sprite.enabled = false;

        if (collectEffect)
            collectEffect.Play();

        addToNotePool();
    }

    public void Miss()
    {

    }

    void addToNotePool()
    {
        StartCoroutine(delayedDestroy());
    }

    IEnumerator delayedDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
