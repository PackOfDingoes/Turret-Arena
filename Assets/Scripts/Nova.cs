using UnityEngine;
using System.Collections;
using System;

public class Nova : MonoBehaviour
{
    public float delay = 0.75f;
    public float novaScale = 1f;
    public float novaSpeed = 0.1f;
	public static bool diePls = false;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(DestroyNova(delay));
    }
	
	// Update is called once per frame
	void Update ()
    {
        novaScale = novaScale + novaSpeed;
        transform.localScale = new Vector2(novaScale, novaScale);
    }

    IEnumerator DestroyNova(float delay)
    {
        yield return new WaitForSeconds(delay);
		diePls = true;
        Destroy(this);
    }

    
}
