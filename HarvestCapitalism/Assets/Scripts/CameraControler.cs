using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject cameraPivot = null;
    [SerializeField] private float xSensitivity = 60;
    [SerializeField] private float ySensitivity = 60;
    [SerializeField] private GameObject player = null;
    private Vector3 lookDirection = new Vector3(1, 0, 0);
    private Vector3 lateralDirection = new Vector3(0, 1, 0);
    private Vector3 playerLookDirection = new Vector3(1, 0, 0);
    float xAngle = 0f;
    float yAngle = 0f;
    float yLimit = 85;


    // Start is called before the first frame update
    void Start()
    {
        //locking the cursor inside the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Catch mouse inputs
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            xAngle += (Mouse.current.delta.x.ReadValue() * xSensitivity * Time.deltaTime) % 180;
            yAngle -= (Mouse.current.delta.y.ReadValue() * ySensitivity * Time.deltaTime) % 180;

            if (yAngle > yLimit) yAngle = yLimit;
            else if (yAngle < -yLimit) yAngle = -yLimit;
        }
        //Lock and Unlock Mouse to click button or control camera
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchCursorLockMode();
        }
        //Finding the direction to look at
        lookDirection = Quaternion.AngleAxis(xAngle, Vector3.up) * Vector3.forward;
        lateralDirection = Vector3.Cross(Vector3.up, lookDirection).normalized;
        lookDirection = Quaternion.AngleAxis(yAngle, lateralDirection) * lookDirection;

        //orienting player according to camera direction
        cameraPivot.transform.forward = lookDirection.normalized;
        playerLookDirection = new Vector3(lookDirection.x, 0f, lookDirection.z);
        player.transform.forward = playerLookDirection;
    }

    public Vector3 GetLateral()
    {
        return lateralDirection;
    }
    public Vector3 GetVertical()
    {
        return lookDirection;
    }
    public void SwitchCursorLockMode()
    {
        if(Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}