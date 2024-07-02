using UnityEngine;
using UnityEngine.UI;

public class Planemovement : MonoBehaviour
{
    public float targetDepth; // Depth the object moves to when button is pressed
    public float speed; // Translation speed
    public Button button; // Reference to the UI button

    private Rigidbody rb; // Reference to the object's Rigidbody
    private float initialDepth; // The object's initial depth

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialDepth = transform.position.y;
    }                                       
                                            
    void Update()                           
    {
        // Handle depth translation based on button state
        if (button.interactable && Input.GetMouseButton(0))
        {
            Dive(targetDepth);
        }
        else
        {
           Fly();
        }
    }

    void Dive(float targetDepth)
    {
        // Perform smooth translation towards target depth
        float newDepth = Mathf.Lerp(transform.position.y, targetDepth, Time.deltaTime * speed);
        GetComponent<Animator>().SetBool("isDiving", true);
        GetComponent<Animator>().SetBool("isFlying", false);
        transform.position = new Vector3(transform.position.x, newDepth, transform.position.z);
    }

    void Fly()
    {
        // Return the object to its initial height smoothly
        float newDepth = Mathf.Lerp(transform.position.y, initialDepth, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, newDepth, transform.position.z);

        GetComponent<Animator>().SetBool("isDiving", false);
        GetComponent<Animator>().SetBool("isFlying", true);
    }
}
