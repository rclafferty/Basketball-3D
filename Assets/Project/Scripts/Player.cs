using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController controller;
    private Basketball basketball;
    private Rigidbody basketballRigidbody;
    private Player player;
    private GameObject playerCamera;

    private float basketballDistance;
    private float basketballThrowingForce;

    private bool holdingBall;
    private bool grabbingBall;

    // Start is called before the first frame update
    void Start()
    {
        basketballDistance = 1.5f;
        basketballThrowingForce = 500.0f;
        holdingBall = true;
        grabbingBall = false;
    }

    public void InitializeObjects()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();

        basketball = controller.BasketballObject;
        basketballRigidbody = controller.BasketballRigidbody;
        player = controller.PlayerObject;
        playerCamera = controller.PlayerCamera;
        GrabBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbingBall)
        {
            grabbingBall = false;
        }
        else if (holdingBall)
        {
            basketball.transform.position = playerCamera.transform.position + (playerCamera.transform.forward * basketballDistance);

            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                ChangeGravity();
                basketballRigidbody.AddForce(playerCamera.transform.forward * basketballThrowingForce);
                controller.StartTimer();
                basketball.ActivateTrail();
            }
        }
    }

    void ChangeGravity()
    {
        basketballRigidbody.useGravity = !holdingBall;
    }

    public bool IsHoldingBall
    {
        get
        {
            return holdingBall;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name != "Basketball")
            return;
        else if (holdingBall)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            GrabBall();
        }
    }

    private void GrabBall()
    {
        controller.StopTimer();
        basketball.DeactivateTrail();
        grabbingBall = true;
        holdingBall = true;
        ChangeGravity();
        basketballRigidbody.angularVelocity = Vector3.zero;
        basketballRigidbody.velocity = Vector3.zero;
    }
}
