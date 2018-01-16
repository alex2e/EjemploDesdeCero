using System;
using System.Collections;
using UnityEngine;

public class Eruction : MonoBehaviour {

    public GameObject prefab;
    public float fireRate = 0.5f;

	// Use this for initialization
	void Start () {
        StartCoroutine(throwObject());
	}

    
    // Update is called once per frame
    void Update () {
		
	}

    //Método para lanzar cubos
    private IEnumerator throwObject()
    {
        yield return new WaitForSeconds(2); //Que se espere 2 segundos para empezar a escupir cubos.
        while (true)
        {
            Instantiate(prefab, transform.position, UnityEngine.Random.rotation);
            yield return new WaitForSeconds(fireRate);
            //yield return null;
        }
    }
}
