using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float forcevalue = 0.1f;
    public float jumpvalue = 0.1f;
    Rigidbody rigidbody;
    private AudioSource audiosource;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    // Para los movimientos cinemáticos, se actualiza por cada frame.
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.01f)
        {
            //Con el ForceMode, en lugar de aplicarle una fuerza como cuando se mueve, es un impulso.
            rigidbody.AddForce(Vector3.up * jumpvalue, ForceMode.Impulse);
            audiosource.Play();
        }
    }

    //Se utiliza para las fuerzas físicas.
    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0
            , Input.GetAxis("Vertical")) * forcevalue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si ha chocado con un cubo...
        if (collision.gameObject.tag == "Cubo")
        {
            print("Colision con cubo");
            Destroy(collision.gameObject);
        }
    }
}
