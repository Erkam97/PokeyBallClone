using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FailureWall"))
        {
            BallController._ballController.ResetBall();
            BallController._ballController.levelFailedPanel.SetActive(true);
            Debug.Log("pin failure wall");
        }
    }
}
