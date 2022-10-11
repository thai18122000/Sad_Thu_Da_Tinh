using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    #region Declare Variable
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform body;
    private float xRot;
    #endregion

    void Start(){
        LockCursor();
    }
    void Update(){
        HandleMouseLook();
    }

    private void HandleMouseLook(){
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        arms.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
        body.Rotate(new Vector3(0, mouseX, 0));
    }

    private void LockCursor(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor(){
        Cursor.lockState = CursorLockMode.None;
    }
}
