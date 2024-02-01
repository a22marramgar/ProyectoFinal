using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class Teleport : MonoBehaviour
{

    public GameObject Marca;
    public bool crearMarca=false;
    

  
    void Update()
    {
        if (Keyboard.current.mKey.isPressed && !crearMarca)
        {
            CrearMarca();
            crearMarca = true;


        }
    }


    void CrearMarca()
    {
        // Obtén la posición del jugador
        Vector3 posicionJugador = transform.position;

        // Crea la "Marca" en la posición del jugador
        GameObject nuevaMarca = Instantiate(Marca, posicionJugador, Quaternion.identity);

     

       

    }
}

