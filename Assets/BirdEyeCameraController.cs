using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEyeCameraController : MonoBehaviour
{
    private float positionY;
    private GameObject chicken;

    // Start is called before the first frame update
    void Start()
    {
        this.chicken = GameObject.Find("Toon Chicken");
        positionY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3 (this.chicken.transform.position.x, this.positionY, this.chicken.transform.position.z);
    }
}
