using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    LineRenderer lineRenderer;

    public Transform obje1;
    public Transform obje2;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        Vector3 startPoint = obje1.position;
        Vector3 endPoint = obje2.position;

        float bendAngle = Mathf.Lerp(0f, BallController._ballController.maxLineForce, Vector3.Distance(startPoint, new Vector3(endPoint.x, endPoint.y + BallController._ballController.posY - .2f, endPoint.z)));

        int numPoints = 20;
        Vector3[] linePositions = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);
            float angle = Mathf.Lerp(0f, bendAngle, t);

            Vector3 midPoint = Vector3.Lerp(startPoint, new Vector3(endPoint.x, endPoint.y + BallController._ballController.posY - .2f, endPoint.z), t);
            Vector3 offset = Quaternion.Euler(0f, 0f, angle) * (midPoint - startPoint);
            linePositions[i] = startPoint + new Vector3(startPoint.x, -offset.y, offset.z);
        }

        lineRenderer.positionCount = numPoints;
        lineRenderer.SetPositions(linePositions);
    }
}
