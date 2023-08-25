using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController _ballController;

    public float force;
    [HideInInspector] public float maxLineForce;
    private bool isFlying = false;
    public GameObject levelCompletedPanel;
    public GameObject levelFailedPanel;
    public GameObject ball;
    public GameObject ballFinishLinePoint;
    public GameObject hook;
    private Vector3 offset;
    [HideInInspector] public float posY = 0;
    public float smoothSpeed;
    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 initialHookPosition;
    [HideInInspector] public Vector3 initialBallRendererFinishPosition;
    public Rigidbody rb;
    Vector3 dragStartPosition;

    private void Awake()
    {
        _ballController = this;
    }
    private void Start()
    {
        initialPosition = ball.transform.position;
        initialHookPosition = hook.transform.position;
        initialBallRendererFinishPosition = ballFinishLinePoint.transform.position;
        offset = transform.position - ball.transform.position;
    }

    private void OnMouseDown()
    {
        dragStartPosition = Input.mousePosition;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        isFlying = false;
        hook.transform.position = new Vector3(hook.transform.position.x, ball.gameObject.transform.position.y, hook.transform.position.z);
        ballFinishLinePoint.transform.position = new Vector3(ballFinishLinePoint.transform.position.x, ball.gameObject.transform.position.y, ballFinishLinePoint.transform.position.z);
        transform.position = new Vector3(transform.position.x, ball.gameObject.transform.position.y, transform.position.z);
        hook.SetActive(true);

        ball.transform.parent.position = new Vector3(ball.transform.parent.position.x, posY, ball.transform.parent.position.z);
    }

    private void OnMouseDrag()
    {
        rb.useGravity = false;
        force = dragStartPosition.y - Input.mousePosition.y;

        if (force >= 90)
        {
            posY = -1;
            maxLineForce = 110;
        }
        else if (force <= 0)
        {
            posY = 0;
            maxLineForce = 90;
        }
        else
        {
            posY = -1 * (force / 90);
            maxLineForce = 90 + (20 * (force / 90));
        }
        ball.transform.parent.position = new Vector3(ball.transform.parent.position.x, posY, ball.transform.parent.position.z);
    }

    private void OnMouseUp()
    {
        posY = 0;
        ball.transform.parent.position = new Vector3(ball.transform.parent.position.x, posY, ball.transform.parent.position.z);
        if (force <= 0)
        {
            force = 0;
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            isFlying = false;
            hook.transform.position = new Vector3(hook.transform.position.x, ball.gameObject.transform.position.y, hook.transform.position.z);
            ballFinishLinePoint.transform.position = new Vector3(ballFinishLinePoint.transform.position.x, ball.gameObject.transform.position.y, ballFinishLinePoint.transform.position.z);
            
            hook.SetActive(true);
        }
        else if (force >= 90)
        {
            force = 30;
            rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
            rb.useGravity = true;
            isFlying = true;
            hook.SetActive(false);
        }
        else
        {
            force = 30 * (force / 90);
            rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
            rb.useGravity = true;
            isFlying = true;
            hook.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (isFlying)
        {
            ball.transform.rotation = Quaternion.Euler((rb.velocity.y * force) % 360, ball.transform.rotation.eulerAngles.y, 0);
        }

        Vector3 newPos = Vector3.Lerp(transform.position, offset + ball.transform.position, smoothSpeed);
        transform.position = newPos;

        if (force >= 90)
        {
            ball.transform.parent.position = new Vector3(Random.Range(-.05f, .05f), posY, Random.Range(-.05f, .05f));
        }
        else
        {
            ball.transform.parent.position = new Vector3(0, posY, 0);
        }
    }

    public void ResetBall()
    {
        ball.transform.position = initialPosition;
        hook.transform.position = initialHookPosition;
        ballFinishLinePoint.transform.position = initialBallRendererFinishPosition;
        ball.transform.rotation = Quaternion.Euler(Vector3.zero);
        hook.SetActive(true);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        isFlying = false;
    }

}
