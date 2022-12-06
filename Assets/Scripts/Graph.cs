using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public enum Function
    {
        x,
        x2,
        x3,
        oneOverX,
        ex,
        sin,
        cos,
        tan
    }

    [SerializeField] private Transform pointPrefab;
    [SerializeField] private UI ui;
    [Space(20f)]
    [SerializeField] private float increment = 0.5f;
    [SerializeField] private Function func;

    private Vector2 xSize = new Vector2(-4f, 4f);


    [ContextMenu("Plot Graph")]
    public void PlotGraph()
    {
        func = (Function)ui.dropdown.value;
        

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
    public void ClearGraph()
    {
        while(transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }

    private float CalculatePoint(float x, Function func)
    {
        switch (func)
        {
            case Function.x:
                return x;
            case Function.x2:
                return x * x;
            case Function.x3:
                return x * x * x;
            case Function.oneOverX:
                return 1/x;
            case Function.ex:
                return Mathf.Exp(x);
            case Function.sin:
                return Mathf.Sin(x);
            case Function.cos:
                return Mathf.Cos(x);
            case Function.tan:
                return Mathf.Tan(x);

            default:
                return 0;
        }
    }

    public List<string> GetFunctionNameList()
    {
        List<string> functionNameList = new List<string>();

        foreach(string functionName in Enum.GetNames(typeof(Function)))
        {
            functionNameList.Add(functionName);
        } 

        return functionNameList;
    }


}
