using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public bool isTryUntouchable = false;
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
        if (other.CompareTag("FailureWall"))
        {
            BallController._ballController.ResetBall();
            BallController._ballController.levelFailedPanel.SetActive(true);
            Debug.Log("pin failure wall");
        }

        if (other.CompareTag("UntoucableWall"))
        {
            isTryUntouchable = true;
            Debug.Log("pin untouchable wall");
        }
    }
}
