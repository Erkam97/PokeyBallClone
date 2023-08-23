using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTesting : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineRendererController lineRendererController;

    void Start()
    {
        lineRendererController.SetUpLine(points);
    }
}
