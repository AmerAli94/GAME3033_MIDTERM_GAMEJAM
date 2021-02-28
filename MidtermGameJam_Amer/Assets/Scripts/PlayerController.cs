using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float thrust = 150.0f;
    [SerializeField]  private Rigidbody rb;
    [SerializeField] private float wallBoundaries = 5.0f;
    [SerializeField] private float cameraDistance = 5.0f;

    private float playerBoundaries = 4.99f;
    

    private Vector2 lastMousePos;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody>();

    }
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

    private void FixedUpdate()
    {
        if (GameManager.singleton.IsRunning)
        {
            rb.MovePosition(transform.position + Vector3.forward * 5 * Time.fixedDeltaTime);
        }
    }
    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (transform.position.x < -wallBoundaries)
        {
            pos.x = -playerBoundaries;
        }
        else if(transform.position.x > wallBoundaries)
        {
            pos.x = playerBoundaries;
        }
        if (transform.position.z < Camera.main.transform.position.z - cameraDistance)

        {
            pos.z = Camera.main.transform.position.z + cameraDistance;
        }
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.singleton.IsEnded)
            return;

        if (collision.gameObject.tag == "Obstacle")
            GameManager.singleton.EndGame(false);
    }
}