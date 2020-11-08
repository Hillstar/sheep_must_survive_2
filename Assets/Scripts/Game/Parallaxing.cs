using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;         // Array (list) of all the back- and foregrounds to be parallaxed
    public float smoothing = 1f;            // How smooth the parallax is going to be. Make sure to set this above 0

    private Transform _cam;                  // reference to the main cameras transform
    private Vector3 _previousCamPos;         // the position of the camera in the previous frame
    private float[] _offsetOnZ;         // The proportion of the camera's movement to move the backgrounds by

    // Is called before Start(). Great for references.
    private void Awake()
    {
        // set up camera the reference
        _cam = Camera.main.transform;
    }

    // Use this for initialization
    private void Start()
    {
        // The previous frame had the current frame's camera position
        _previousCamPos = _cam.position;

        // asigning coresponding parallaxScales
        _offsetOnZ = new float[backgrounds.Length];
        for (var i = 0; i < backgrounds.Length; i++)
        {
            _offsetOnZ[i] = backgrounds[i].position.z * -1; // смещение на положительную ось
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        // for each background
        for (var i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            var parallax = (_previousCamPos.x - _cam.position.x) * _offsetOnZ[i];

            // set a target x position which is the current position plus the parallax
            var backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position which is the background's current position with it's target x position
            var backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // set the previousCamPos to the camera's position at the end of the frame
        _previousCamPos = _cam.position;
    }
}
