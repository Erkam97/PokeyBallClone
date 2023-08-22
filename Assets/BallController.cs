using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region 1
    public float dragMultiplier = .05f;
    public float rotationMultiplier = 3f;
    private Rigidbody rb;
    private bool isFlying = false;
    private Vector3 initialPosition;
    private float startY;

    private float deltaY;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFlying)
        {
            startY = Input.mousePosition.y;
            isFlying = true;

            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0) && isFlying)
        {
            float currentY = Input.mousePosition.y;
            /*float */
            deltaY = startY - currentY;

            if (deltaY > 360)
            {
                deltaY = 360;
            }

            //rb.velocity = new Vector3(rb.velocity.x, -deltaY * dragMultiplier, rb.velocity.z);
        }

        if (Input.GetMouseButtonUp(0) && isFlying)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            //transform.rotation = Quaternion.Euler(transform.rotation.x + dragMultiplier, 0, 0);
            //float rotationAmount = rb.velocity.y * rotationMultiplier;

            Debug.Log(-deltaY);

            rb.velocity = new Vector3(rb.velocity.x, -deltaY * dragMultiplier, rb.velocity.z);
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);


            rb.useGravity = true;
            isFlying = false;
        }

        if (!isFlying)
        {
            transform.rotation = Quaternion.Euler(rb.velocity.y * rotationMultiplier, transform.rotation.eulerAngles.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        isFlying = false;
    }
    #endregion

    #region 2
    //public float pokeForce = 5f;
    //public float flickForce = 10f;
    //private Rigidbody rb;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //private void Update()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Poke();
    //        rb.velocity = Vector3.zero;
    //        rb.useGravity = false;
    //    }


    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Flick();
    //        rb.useGravity = true;
    //    }
    //}

    //private void Poke()
    //{
    //    rb.velocity = new Vector3(rb.velocity.x, pokeForce, rb.velocity.z);
    //}

    //private void Flick()
    //{
    //    Vector3 flickDirection = new Vector3(0f, flickForce, 0f);
    //    rb.AddForce(flickDirection, ForceMode.Impulse);
    //}
    #endregion
}
