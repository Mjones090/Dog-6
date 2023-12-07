using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement player;
    private float sensitivity = 500f;
    private float clampAngle = 85f;

    private float verticalRotation;
    private float horizontalRotation;



    // Start is called before the first frame update
    void Start()
    {
        this.verticalRotation = this.transform.localEulerAngles.x;
        this.horizontalRotation = this.transform.eulerAngles.y;
    }

    // Update is called once per frame
    private void Update()
    {
        Look();
        Debug.DrawRay(this.transform.position, this.transform.forward * 2, Color.red);

    }

    private void Look()
    {
        float mouseVertical = -Input.GetAxis("Mouse Y");
        float mouseHorizontal = -Input.GetAxis("Mouse X");

        this.verticalRotation += mouseVertical * this.sensitivity * Time.deltaTime;
        this.horizontalRotation += mouseHorizontal * this.sensitivity * Time.deltaTime;

        this.verticalRotation = Mathf.Clamp(this.verticalRotation, -this.clampAngle, this.clampAngle);

        this.transform.localRotation = Quaternion.Euler(this.verticalRotation, 0f, 0f);
        this.player.transform.localRotation = Quaternion.Euler(0f, this.horizontalRotation, 0f);
    }
}

