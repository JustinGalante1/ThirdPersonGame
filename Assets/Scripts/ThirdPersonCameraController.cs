using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour {

    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    private GameController gameController;
    
	
    // Use this for initialization
	void Start ()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

    private void LateUpdate()
    {
        camControl();
    }

    public void camControl()
    {
        if (gameController.allowCameraControl)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
