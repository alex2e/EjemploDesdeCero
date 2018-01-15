using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float forcevalue = 0.1f;
    public float jumpvalue = 0.1f;
    Rigidbody rigidbody;
    private AudioSource audiosource;
    private GameObject capsules;
    public GameObject prefab;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        capsules = GameObject.Find("Capsules"); //Para buscarlo por nombre 
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
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical")) * forcevalue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si ha chocado con un cubo...
        if (collision.gameObject.tag == "Cube")
        {
            print("Colision con cubo");
            Destroy(collision.gameObject);
        }

        //Si ha chocado con una capsula...
        if (collision.gameObject.tag == "Capsule")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color *= 1.2f;
            //collision.gameObject.GetComponent<MeshRenderer>().material.SetColor("Negro", new Color(0.2F, 0.3F, 0.4F, 0.5F));
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Si ha dejado de chocar con un cubo...
        if (collision.gameObject.tag == "Cube")
        {
           //TODO
        }

        //Si ha chocado con una capsula...
        if (collision.gameObject.tag == "Capsule")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color /= 1.2f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform child in capsules.GetComponentInChildren<Transform>())
        {
            if (child.gameObject.tag.Equals("Capsule"))
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
                child.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        //Crea capsula aleatoria
        Instantiate(prefab, new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)), Quaternion.identity);
    }
}
