using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public RaceManager RM;
    public Transform StaticCamTransform;
    public Transform BeginCamTransform;
    public Transform EndCamTransform;

    Transform PreviousTarget;
    public GameObject Target;

    public Vector3 Offset;

    int CameraIndex = 3;

    public float AutoSwitchCooldown = 5f;

    void Update()
    {
        if (!RM.CountdownStarted)
        {

            BeginCam();

        }

        else if (RM.RaceEnded)
        {

            EndCam();

        }

        else
        {

            SwitchCam();

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
                case 3:
                    EndCam();
                    break;
            }
        }
    }

    void SwitchCam()
    {

        if (CameraIndex > 3) CameraIndex = 0;
        else if (CameraIndex < 0) CameraIndex = 3;

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
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + Offset, Time.deltaTime * 7f);
        Offset = - Target.transform.right * 12f + Target.transform.up * 7f;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position + new Vector3(0, 1.3f, 0), Vector3.up), Time.deltaTime * 7f);
    }

    void MediumRangeCam()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + Offset, Time.deltaTime * 7f);
        Offset = Target.transform.forward * 13f + Target.transform.up * 13f ;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position + new Vector3(0,0.7f,0) - transform.position, Vector3.up), Time.deltaTime * 7f);
    }

    void StaticCam()
    {
        transform.position = Vector3.Lerp(transform.position, StaticCamTransform.position, Time.deltaTime * 7f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position + new Vector3(0, 0.7f, 0) - transform.position, Vector3.up), Time.deltaTime * 7f);
    }

    void BeginCam()
    {

        transform.position = Vector3.Lerp(transform.position, BeginCamTransform.position, Time.deltaTime * 7f);
        transform.rotation = Quaternion.Slerp(transform.rotation, BeginCamTransform.rotation, Time.deltaTime * 7f);

    }

    void EndCam()
    {

        transform.position = Vector3.Lerp(transform.position, EndCamTransform.position, Time.deltaTime * 7f);
        transform.rotation = Quaternion.Slerp(transform.rotation, EndCamTransform.rotation, Time.deltaTime * 7f);

    }

}