using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Campo que representa al objeto Jugador.
    public GameObject player;
    //Variable para almacenar la distancia entre la cámara y el jugador.
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        // Se establece la posición de la cámara para que sea la misma que
        // más la distancia calculada al principio.
        transform.position = player.transform.position + offset;
    }
}
