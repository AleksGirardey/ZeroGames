using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public Transform Target;
    public float speed;

    private void Update()
    {
        Vector3 DirTarget = Target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, DirTarget, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
       
}
