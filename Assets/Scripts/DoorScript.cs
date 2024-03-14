using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Transform leftDoor; 
    [SerializeField] private Transform rightDoor;

    [SerializeField] private Vector3 leftDoorOpenPoint;
    [SerializeField] private Vector3 rightDoorOpenPoint;
    [SerializeField] private Vector3 leftDoorClosePoint;
    [SerializeField] private Vector3 rightDoorClosePoint;

    [SerializeField] private float openCloseSpeed = 5f;

    [SerializeField] private bool isOpening = false;


    private void FixedUpdate()
    {
        if (isOpening)
            BeginOpenDoor();
        else
            BeginCloseDoor();
    }

    private void BeginCloseDoor()
    {
        if(leftDoor.localPosition == leftDoorClosePoint) return;
        if(rightDoor.localPosition == rightDoorClosePoint) return;
        leftDoor.localPosition =
            Vector3.Slerp(leftDoor.localPosition, leftDoorClosePoint, Time.fixedDeltaTime * openCloseSpeed);
        rightDoor.localPosition =
            Vector3.Slerp(rightDoor.localPosition, rightDoorClosePoint, Time.fixedDeltaTime * openCloseSpeed);
    }

    private void BeginOpenDoor()
    {
        if(leftDoor.localPosition == leftDoorOpenPoint) return;
        if(rightDoor.localPosition == rightDoorOpenPoint) return;
        leftDoor.localPosition =
            Vector3.Slerp(leftDoor.localPosition, leftDoorOpenPoint, Time.fixedDeltaTime * openCloseSpeed);
        rightDoor.localPosition =
            Vector3.Slerp(rightDoor.localPosition, rightDoorOpenPoint, Time.fixedDeltaTime * openCloseSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter");
        if(!other.gameObject.CompareTag("Player")) return;
        isOpening = true;
    }

    // private void OnCollisionStay(Collision other)
    // {
    //     if(!other.gameObject.CompareTag("Player")) return;
    //     isOpening = true;
    //     leftDoor.localPosition = Vector3.Slerp(leftDoor.localPosition, leftDoorOpenPoint, Time.fixedDeltaTime * openCloseSpeed);
    // }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("Exit");
        if(!other.gameObject.CompareTag("Player")) return;
        isOpening = false;
    }
}
