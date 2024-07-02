using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlanee : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera based on the plane's position and the offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Rotate the camera to look at the plane
            transform.LookAt(target);
        }
    }
}
