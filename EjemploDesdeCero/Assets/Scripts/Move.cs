using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed = 1f;
    Rigidbody rigidbody;
    public float forceValue = 0.1f;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>(); //Cogemos la referencia al Rigibody	
	}
	
	//Se usa para el movimiento cinematico, una vez por frame.
	void Update () {
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime); //Imput devuelve un valor entre -1 y 1 dependiendo de la tecla pulsada para un eje.
	}

    //Se usa para el movimiento fisico, no depende de los fps
    void FixedUpdate() 
    {
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * forceValue);
    }
}
