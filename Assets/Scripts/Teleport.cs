using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{

    public GameObject Marca;
    

  
    void Update()
    {
        if (Keyboard.current.mKey.isPressed)
        {
            CrearMarca();


        }
    }


    void CrearMarca()
    {
        // Obtén la posición del jugador
        Vector3 posicionJugador = transform.position;

        // Ajusta la posición del objeto "Marca" para que sea más visible (ajusta según tus necesidades)
        posicionJugador += new Vector3(0, 1, 0); // Ajusta la altura si es necesario

        // Crea la "Marca" en la posición del jugador
        GameObject nuevaMarca = Instantiate(Marca, posicionJugador, Quaternion.identity);

        // Asegúrate de que la instancia tenga la misma escala que el prefab
        nuevaMarca.transform.localScale = Marca.transform.localScale;

    }
}

