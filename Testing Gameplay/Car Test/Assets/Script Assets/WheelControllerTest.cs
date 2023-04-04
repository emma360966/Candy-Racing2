using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControllerTest : MonoBehaviour
{
 [SerializeField] WheelCollider frontRight;
 [SerializeField] WheelCollider frontLeft;
 [SerializeField] WheelCollider rearRight;
 [SerializeField] WheelCollider rearLeft;

 [SerializeField]  Transform frontRightTransform;
 [SerializeField]  Transform frontLeftTransform;
 [SerializeField]  Transform rearRightTransform;
 [SerializeField]  Transform rearLeftTransform;

 public float acceleration = 500f;
 public float breakingForce = 300f;
 public float maxTurnAngle = 15f;
 

 private float currentAcceleration = 0f;
 private float currentBreakForce = 0f;
 private float currentTurnAngle = 0f;

 private void FixedUpdate()
 {
 //Get forward/reverse acceleration from the vertical axis (W and S keys)
 currentAcceleration = acceleration * Input.GetAxis("Vertical");     
     
 //Get forward/reverse acceleration from the vertical axis (W and S keys)
 if(Input.GetKey(KeyCode.Space))
 
     currentBreakForce = breakingForce;  
 
 else
 
     currentBreakForce = 0f;
 
//Apply acceleration to front wheels
 frontRight.motorTorque = currentAcceleration;
 frontLeft.motorTorque = currentAcceleration;
 rearRight.motorTorque = currentAcceleration;
 rearLeft.motorTorque = currentAcceleration;
//Apply brake force to rear wheels 
 frontRight.brakeTorque = currentBreakForce;
 frontLeft.brakeTorque = currentBreakForce;
 rearRight.brakeTorque = currentBreakForce;
 rearLeft.brakeTorque = currentBreakForce;


//Steering time
  currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
  frontLeft.steerAngle = currentTurnAngle;
  frontRight.steerAngle = currentTurnAngle;

//Update meshes :)
UpdateWheel(frontLeft,frontLeftTransform);
UpdateWheel(frontRight, frontRightTransform);
UpdateWheel(rearRight, rearRightTransform);
UpdateWheel(rearLeft, rearLeftTransform);

 }

 void UpdateWheel(WheelCollider col, Transform trans)
 {
  Vector3 position;
  Quaternion rotation;
  col.GetWorldPose(out position, out rotation);
  
 //Set wheel turn
 RotationCorrectionRight(frontRightTransform);
 RotationCorrectionRight(rearRightTransform);

 RotationCorrectionLeft(frontLeftTransform);
 RotationCorrectionLeft(rearRightTransform);
 trans.position = position;
 trans.rotation = rotation;
 

 
 }
 
 // for passenger side wheels
 private void RotationCorrectionRight(Transform position)
 {
  Quaternion rotate = transform.rotation;
  rotate = rotate * Quaternion.Euler(0,360,0);
  transform.rotation = rotate;
 }
 // for driver side wheels
 private void RotationCorrectionLeft(Transform position)
 {
  Quaternion rotate = transform.rotation;
  rotate = rotate * Quaternion.Euler(0, 360, 0);
  transform.rotation = rotate;
 }
}
