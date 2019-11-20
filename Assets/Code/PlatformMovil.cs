using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovil : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Vector3 start, end;

    void Start()
    {
        if(target != null)
        {
            target.parent = null;  //Hacemos que no sea hijo de la plataforma
            start = transform.position;
            end = target.position;
        }
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
        if(transform.position.x == target.position.x) //si la plataforma Movil llega al objeto target, cambia la posición del target
        {
            target.position = (target.position == start) ? end : start;
        }
    }
}

