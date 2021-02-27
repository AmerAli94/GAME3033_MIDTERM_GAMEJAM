using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float thrust = 5.0f;
    [SerializeField]  private Rigidbody rb;
    [SerializeField] private float playerBoundaries = 5.0f;
    [SerializeField] private float cameraDistance = 5.0f;
    private Vector2 lastMousePos;

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDeltaPos = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            Vector2 currMousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
                lastMousePos = currMousePos;

            mouseDeltaPos = currMousePos - lastMousePos;
            lastMousePos = currMousePos;

            Vector3 force = new Vector3(mouseDeltaPos.x, 0, mouseDeltaPos.y) * thrust;
            rb.AddForce(force);
        }
        else
        {
            lastMousePos = Vector3.zero;
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (transform.position.x < -playerBoundaries)
        {
            pos.x = -playerBoundaries;
        }
        else if(transform.position.x > playerBoundaries)
        {
            pos.x = playerBoundaries;
        }
        transform.position = pos;
    }
}
