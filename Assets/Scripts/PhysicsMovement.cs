using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PhysicsMovement : MonoBehaviour
{
    public Transform pivot;
    public Animator animator;
    public Rigidbody rigidbody;

    public float forward;
    public float lateral;

    float forwardPrevious;
    float lateralPrevious;

    ICinemachineCamera virtualCameraPrevious;

    bool keepHeading;


    // Start is called before the first frame update
    void Start()
    {
        forwardPrevious = forward;
        lateralPrevious = lateral;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float previousVelocityUp;
        previousVelocityUp = rigidbody.velocity.y;

        // Este código mira si la cámara que está seleccionada actualmente por cinemachine
        // es de tipo orbital y en ese caso deja de aplicar el efecto de mantener la dirección actual

        ICinemachineCamera virtualCamera;
        virtualCamera = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;

        if (virtualCameraPrevious != virtualCamera && virtualCamera != null)
        {
            if (virtualCamera is CinemachineVirtualCamera)
            {
                CinemachineVirtualCamera v = (CinemachineVirtualCamera)virtualCamera;

                if (v != null)
                {
                    CinemachineComponentBase body;
                    body = v.GetCinemachineComponent(CinemachineCore.Stage.Body);
                    if (body == v.GetCinemachineComponent<CinemachineOrbitalTransposer>())
                    {
                        keepHeading = false;
                    }
                    else
                    {
                        keepHeading = true;
                    }
                }

            }

        }

        if ((lateral != 0 || forward != 0) && (forwardPrevious != forward || lateralPrevious != lateral || keepHeading == false))
        {
            Vector3 direction = new Vector3(lateral, 0, forward);
            direction = Camera.main.transform.TransformDirection(direction);
            direction = new Vector3(direction.x, 0, direction.z);

            rigidbody.velocity = direction * 6;




            pivot.rotation = Quaternion.LookRotation(direction, Vector3.up);


            animator.SetFloat("Speed", direction.magnitude);

        }
        else if(lateral == 0 && forward == 0)
        {
            rigidbody.velocity = Vector3.zero;
        }

        rigidbody.velocity = new Vector3(rigidbody.velocity.x,
                                         previousVelocityUp,
                                         rigidbody.velocity.z);



        forwardPrevious = forward;
        lateralPrevious = lateral;

        virtualCameraPrevious = virtualCamera;
    }
}
