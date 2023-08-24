using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    LineRenderer lineRenderer;
    //Transform[] points;

    public Transform obje1;
    public Transform obje2;
    public float maxBendAngle = 45f;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    //public void SetUpLine(Transform[] points)
    //{
    //    lineRenderer.positionCount = points.Length;
    //    this.points = points;
    //}
    void Update()
    {
        //for (int i = 0; i < points.Length; i++)
        //{
        //    lineRenderer.SetPosition(i, points[i].position);
        //}

        Vector3 startPoint = obje1.position;
        Vector3 endPoint = obje2.position;

        float yDistance = Mathf.Abs(obje1.position.y - obje2.position.y);
        float normalizedY = Mathf.Clamp01(yDistance / maxBendAngle);

        float bendAngle = normalizedY * maxBendAngle;

        int numPoints = 20;
        Vector3[] linePositions = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);
            float angle = Mathf.Lerp(0f, bendAngle, t);

            Vector3 midPoint = Vector3.Lerp(startPoint, endPoint, t);
            Vector3 offset = Quaternion.Euler(0f, 0f, angle) * (midPoint - startPoint);
            linePositions[i] = startPoint + offset;
        }

        lineRenderer.positionCount = numPoints;
        lineRenderer.SetPositions(linePositions);
    }

//    Vector3 startPoint = obje1.position;
//    Vector3 endPoint = obje2.position;

//    Vector3 middlePoint = (startPoint + endPoint) / 2f;

//    float bendAngle = Mathf.Lerp(0f, maxBendAngle, Vector3.Distance(startPoint, endPoint));

//    int numPoints = 20;
//    Vector3[] linePositions = new Vector3[numPoints];

//        for (int i = 0; i<numPoints; i++)
//        {
//            float t = (float)i / (numPoints - 1);
//    float angle = Mathf.Lerp(0f, bendAngle, t);

//    Vector3 offset = Quaternion.Euler(0f, 0f, angle) * (middlePoint - startPoint);
//    linePositions[i] = startPoint + offset;
//        }

//lineRenderer.positionCount = numPoints;
//lineRenderer.SetPositions(linePositions);
}
