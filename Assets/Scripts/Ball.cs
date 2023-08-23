using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            BallController._ballController.rb.velocity = Vector3.zero;
            BallController._ballController.rb.useGravity = false;
            BallController._ballController.levelCompletedPanel.SetActive(true);
            Debug.Log("finish");
        }

        if (other.CompareTag("Plane"))
        {
            BallController._ballController.ResetBall();
            BallController._ballController.levelFailedPanel.SetActive(true);
            Debug.Log("failed");
        }
    }
}