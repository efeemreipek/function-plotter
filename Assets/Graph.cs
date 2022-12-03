using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public enum Function
    {
        x,
        x2,
        Sin,
        Cos
    }

    [SerializeField] private Transform pointPrefab;
    [SerializeField] private float increment = 0.5f;
    [SerializeField] private Function func;

    private Vector2 xSize = new Vector2(-4f, 4f);


    [ContextMenu("Plot Graph")]
    void PlotGraph()
    {
        for (float i = xSize.x; i <= xSize.y; i += increment)
        {
            Transform point = Instantiate(pointPrefab);
            point.SetParent(transform);

            point.localPosition = new Vector3(i, 0f, CalculatePoint(i, func));
            if (point.position.z < xSize.x || point.position.z > xSize.y)
            {
                DestroyImmediate(point.gameObject);
                continue;
            }
        }
    }

    [ContextMenu("Clear Graph")]
    void ClearGraph()
    {
        while(transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }

    float CalculatePoint(float x, Function func)
    {
        switch (func)
        {
            case Function.x:
                return x;
            case Function.x2:
                return x * x;
            case Function.Sin:
                return Mathf.Sin(x);
            case Function.Cos:
                return Mathf.Cos(x);

            default:
                return 0;
        }
    }
}
