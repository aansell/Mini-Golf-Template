using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallManager : MonoBehaviour
{
    public Vector3 lastLocation;

    public int score;

    public InputAction selectAction;

    private void Start()
    {
        lastLocation = this.transform.position;
        score = 0;
        selectAction.Enable();
        selectAction.started += context => MoveToBall();
    }

    public void MoveToBall()
    {
        if (this.gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude == 0 && Vector3.Distance(this.transform.position, FindFirstObjectByType<XROrigin>().gameObject.transform.position) >= 1)
        {
            GameObject XRSetup = FindFirstObjectByType<XROrigin>().gameObject;
            XRSetup.transform.position = this.transform.position + new Vector3(0f, 0.95f, 0f);
            lastLocation = this.transform.position;
            score++;
        }
    }
    
    public void OutOfBounds()
    {
        this.transform.position = lastLocation;
        score++;
    }
}
