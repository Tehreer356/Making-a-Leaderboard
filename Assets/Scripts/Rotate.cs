using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static Rotate instance;
    public Transform rotationPoint;
    public float rotationSpeed;
    public bool canRotate = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            RotatePlane();
        }

    }
    public void RotatePlane()
    {
        
        transform.RotateAround(rotationPoint.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}


