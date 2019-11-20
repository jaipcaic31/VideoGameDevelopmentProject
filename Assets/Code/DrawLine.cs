using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform from;
    public Transform to;

    private void OnDrawGizmosSelected() //Dibujar una linea donde se movera la plataforma
    {
        if(from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position,0.20f);
            Gizmos.DrawSphere(to.position, 0.20f);
        }
    }

}
