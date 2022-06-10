using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    public WheelAlignment[] steerableWheels;

    public float BreakPower;

    public float Horizontal;
    public float Vertical;
    //Steering variables
    public float wheelRotateSpeed;
    public float wheelSteeringAngle;

    //Motor variables
    public float wheelAcceleration;
    public float wheelMaxSpeed;

    public Rigidbody RB;
    public GameObject textRotate;


    private void Start()
    {
        textRotate.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        wheelControl();
        rotateIfFall();

    }


    //Applies steering and motor torque
    void wheelControl()
    {

        for (int i = 0; i < steerableWheels.Length; i++)
        {
            //Sets default steering angle
            steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, 0, Time.deltaTime * wheelRotateSpeed);
            //Sets default motor speed
            steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, 0, Time.deltaTime * wheelAcceleration);

            //Motor controls

            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");


            if ((Vertical != 0 || Horizontal != 0))
            {
         
                RB.drag = 0.03f;

                if (Horizontal > 0.1)
                {
                    steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
                }

                if (Horizontal < -0.1)
                {
                    steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, -wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
                }

                if (Vertical > 0.1)
                {
                    steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration);
                }

                if (Vertical < -0.1)
                {
                    steerableWheels[i].wheelCol.motorTorque = Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration * BreakPower);
                }

                
            }
            else
            {
                RB.drag = 0.3f;
            }

        }
    }

    void rotateIfFall()
    {
           
        if (transform.localEulerAngles.x >= 300 && !steerableWheels[0].wheelCol.isGrounded && !steerableWheels[1].wheelCol.isGrounded)
        {
            textRotate.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.rotation = Quaternion.identity;
                textRotate.SetActive(false);
            }
        }
        else
        {
            textRotate.SetActive(false);
        }
    }

   

}
