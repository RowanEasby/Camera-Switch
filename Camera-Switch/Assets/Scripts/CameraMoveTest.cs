using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraMoveTest : MonoBehaviour
{
    //Creats assignable variables for the cameras in the scene
    public CinemachineVirtualCamera BlueCam;
    public CinemachineVirtualCamera RedCam;
    public CinemachineVirtualCamera MainCam;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //When the user Left clicks activate the function "CastRay"
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }

        //When space is pressed the camera returns to the default position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MainCamera();
        }
    }


    void CastRay()
    {
        //Casts a Ray called "ray" from the cameras current position to the mouses location
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Names the Cast ray as "hit"
        RaycastHit hit;
        //Check if the ray has hit something
        if (Physics.Raycast(ray, out hit, 100))
        {
            //If the name of the collider of the gameobject is "Red Cube" (if the red cube is clicked), switch to the Red Camera
            if (hit.collider.gameObject.name == "Red Cube")
            {
                RedCamera();
            }

            //If the name of the collider of the gameobject is "Blue Cube" (if the blue cube is clicked), switch to the Blue Camera
            if (hit.collider.gameObject.name == "Blue Cube")
            {
                BlueCamera();
            }
            

        }

    }

   //Turns on RedCam and turns off other cams
    public void RedCamera() {

        BlueCam.gameObject.SetActive(false);
        RedCam.gameObject.SetActive(true);
        MainCam.gameObject.SetActive(false);
    }
    //Turns on BlueCam and turns off other cams
    public void BlueCamera() {

        BlueCam.gameObject.SetActive(true);
        RedCam.gameObject.SetActive(false);
        MainCam.gameObject.SetActive(false);
    }
    //Turns on MainCam and turns off other cams
    public void MainCamera() {

        BlueCam.gameObject.SetActive(false);
        RedCam.gameObject.SetActive(false);
        MainCam.gameObject.SetActive(true);
    }
}
