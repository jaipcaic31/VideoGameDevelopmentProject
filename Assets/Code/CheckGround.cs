using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();//Instanciamos al jugador

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") { //Preguntar si es un suelo al momento de colisionar 

            player.grounded = true;

        }
        else if (collision.gameObject.tag == "Platform")
        { //Preguntar si es un suelo al momento de colisionar 

            player.grounded = true;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { //Preguntar si es un suelo al momento de colisionar 

            player.grounded = false;

        }
        else if (collision.gameObject.tag == "Platform")
        { //Preguntar si es un suelo al momento de colisionar 

            player.grounded = false;

        }
    }

}
