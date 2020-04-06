using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dot_Truck : System.Object
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public GameObject leftWheelMesh;
    public GameObject rightWheelMesh;
    public bool motor;
    public bool steering;
    public bool reverseTurn;
}
public class Dot_Truck_controller : MonoBehaviour
{

    public float motorMaxTorque;
    public Rigidbody rp;
    public float maxSteeringAngle;
    public GameObject gC;
    public GameObject aux;
    public List<Dot_Truck> truckInfos;
    

    // Start is called before the first frame update
    void Start()
    {
        rp = GetComponent<Rigidbody>();
        gC = GameObject.Find("GameController");

    }

    // Update is called once per frame
    void Update()
    {
        float motor = motorMaxTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        float breakTorque = Mathf.Abs(Input.GetAxis("Jump"));
        if (breakTorque > 000.1)
        {
            breakTorque = motorMaxTorque;
            motor = 0;
            rp.drag = 1.5f;
        }
        else
        {
            breakTorque = 0;
            rp.drag = 0;
        }

        foreach (Dot_Truck truckInfo in truckInfos)
        {

            if (truckInfo.steering == true)
            {
                truckInfo.leftWheel.steerAngle = truckInfo.rightWheel.steerAngle = ((truckInfo.reverseTurn) ? -1 : 1) * steering; 
            }
            if (truckInfo.motor == true)
            {
                truckInfo.leftWheel.motorTorque = motor;
                truckInfo.rightWheel.motorTorque = motor;
            }

            truckInfo.leftWheel.brakeTorque = breakTorque;
            truckInfo.rightWheel.brakeTorque = breakTorque;

            VisualizeWheel(truckInfo);
        }
    }

    public void VisualizeWheel(Dot_Truck wheelPair)
    {
        Quaternion quot;
        Vector3 pos;
        wheelPair.leftWheel.GetWorldPose(out pos, out quot);
        wheelPair.leftWheelMesh.transform.position = pos;
        wheelPair.leftWheelMesh.transform.rotation = quot;
        wheelPair.rightWheel.GetWorldPose(out pos, out quot);
        wheelPair.rightWheelMesh.transform.position = pos;
        wheelPair.rightWheelMesh.transform.rotation = quot;

    }
}
