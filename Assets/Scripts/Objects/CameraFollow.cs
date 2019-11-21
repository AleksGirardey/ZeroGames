using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform StaticCamTransform;
    public GameObject Target;

    Vector3 Offset;

    int CameraIndex;

    float AutoSwitchCooldown = 5f;

    void Update()
    {

        switch (CameraIndex)
        {
            case 0:
                StaticCam();
                break;
            case 1:
                CloseCam();
                break;
            case 2:
                MediumRangeCam();
                break;
        }

        SwitchCam();
    }

    void SwitchCam()
    {

        if (CameraIndex > 2) CameraIndex = 0;
        else if (CameraIndex < 0) CameraIndex = 2;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AutoSwitchCooldown = 5f;
            CameraIndex--;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AutoSwitchCooldown = 5f;
            CameraIndex++;
        }

        AutoSwitchCooldown -= Time.deltaTime;

        if (AutoSwitchCooldown <= 0)
        {
            AutoSwitchCooldown = 5f;
            CameraIndex++;
        }

    }

    void CloseCam()
    {
        transform.position = Target.transform.position + Offset;
        Offset = - Target.transform.right * 3f;
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up);
    }

    void MediumRangeCam()
    {
        transform.position = Target.transform.position + Offset;
        Offset = Target.transform.forward * 10f + Target.transform.up * 10f ;
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up);
    }

    void StaticCam()
    {
        transform.position = StaticCamTransform.position;
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up);
    }

}