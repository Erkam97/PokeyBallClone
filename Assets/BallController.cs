using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force;
    private bool isFlying = false;
    public GameObject hook;
    private Vector3 initialPosition;
    private float deltaY;
    private Rigidbody rb;
    float maxForce = 10f;
    float minSwipeDelta = 50f;
    Vector3 dragStartPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        dragStartPosition = Input.mousePosition;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        isFlying = false;
        hook.transform.position = new Vector3(hook.transform.position.x, gameObject.transform.position.y, hook.transform.position.z);
        hook.SetActive(true);
    }

    private void OnMouseDrag()
    {
        rb.useGravity = false;
        //Debug.Log(dragStartPosition.y - Input.mousePosition.y);
        //if ((dragStartPosition.y - Input.mousePosition.y) > 0)
        //{
        //    Debug.Log("max hiz oldu");
        //    force = 50;
        //}
        if ((dragStartPosition.y - Input.mousePosition.y) <= 0)
        {
            //Debug.Log("hiz sbit oldu");
            force = 0;
        }
        else
        {
            force = (dragStartPosition.y - Input.mousePosition.y) / 10;
            //Debug.Log("force = " + force);
        }
    }

    private void OnMouseUp()
    {
        if (force == 0)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            isFlying = false;
            hook.transform.position = hook.transform.position = new Vector3(hook.transform.position.x, gameObject.transform.position.y, hook.transform.position.z); ;
            hook.SetActive(true);
        }
        else
        {
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
            transform.rotation = Quaternion.Euler((rb.velocity.y * force) % 360, transform.rotation.eulerAngles.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            ResetBall();
            Debug.Log("finish");
        }
    }

    private void ResetBall()
    {
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        isFlying = false;
    }

    //#region 1
    //public float dragMultiplier = .05f;
    //public float rotationMultiplier = 3f;
    //private Rigidbody rb;
    //private bool isFlying = false;
    //private Vector3 initialPosition;
    //private float startY;

    //private float deltaY;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    initialPosition = transform.position;
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && !isFlying)
    //    {
    //        startY = Input.mousePosition.y;
    //        isFlying = true;

    //        rb.velocity = Vector3.zero;
    //        rb.useGravity = false;
    //        transform.GetChild(0).gameObject.SetActive(true);
    //    }

    //    if (Input.GetMouseButton(0) && isFlying)
    //    {
    //        float currentY = Input.mousePosition.y;
    //        /*float */
    //        deltaY = startY - currentY;

    //        if (deltaY > 360)
    //        {
    //            deltaY = 360;
    //        }

    //        //rb.velocity = new Vector3(rb.velocity.x, -deltaY * dragMultiplier, rb.velocity.z);
    //    }

    //    if (Input.GetMouseButtonUp(0) && isFlying)
    //    {
    //        transform.GetChild(0).gameObject.SetActive(false);
    //        //transform.rotation = Quaternion.Euler(transform.rotation.x + dragMultiplier, 0, 0);
    //        //float rotationAmount = rb.velocity.y * rotationMultiplier;

    //        Debug.Log(-deltaY);

    //        rb.velocity = new Vector3(rb.velocity.x, -deltaY * dragMultiplier, rb.velocity.z);
    //        rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);


    //        rb.useGravity = true;
    //        isFlying = false;
    //    }

    //    if (!isFlying)
    //    {
    //        transform.rotation = Quaternion.Euler(rb.velocity.y * rotationMultiplier, transform.rotation.eulerAngles.y, 0);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Finish"))
    //    {
    //        ResetBall();
    //    }
    //}

    //private void ResetBall()
    //{
    //    transform.position = initialPosition;
    //    rb.velocity = Vector3.zero;
    //    isFlying = false;
    //}
    //#endregion

    //#region 2
    ////public float pokeForce = 5f;
    ////public float flickForce = 10f;
    ////private Rigidbody rb;

    ////private void Start()
    ////{
    ////    rb = GetComponent<Rigidbody>();
    ////}

    ////private void Update()
    ////{

    ////    if (Input.GetMouseButtonDown(0))
    ////    {
    ////        Poke();
    ////        rb.velocity = Vector3.zero;
    ////        rb.useGravity = false;
    ////    }


    ////    if (Input.GetMouseButtonUp(0))
    ////    {
    ////        Flick();
    ////        rb.useGravity = true;
    ////    }
    ////}

    ////private void Poke()
    ////{
    ////    rb.velocity = new Vector3(rb.velocity.x, pokeForce, rb.velocity.z);
    ////}

    ////private void Flick()
    ////{
    ////    Vector3 flickDirection = new Vector3(0f, flickForce, 0f);
    ////    rb.AddForce(flickDirection, ForceMode.Impulse);
    ////}
    //#endregion
}
