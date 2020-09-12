using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCameraController : MonoBehaviour
{
    private float positionY;
    private GameObject chicken;
    private GameObject ninjaCamera;

    // Start is called before the first frame update
    void Start()
    {
        this.chicken = GameObject.Find("Toon Chicken");
        this.ninjaCamera = GameObject.Find("NinjaCamera");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.chicken.transform.position.x, this.chicken.transform.position.y + 0.3f, this.chicken.transform.position.z);

        this.transform.LookAt(this.ninjaCamera.transform.position);
        this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + 90);
    }
}
