using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private Graph graph;
    public TMP_Dropdown dropdown;


    private void Awake()
    {
        dropdown.AddOptions(graph.GetFunctionNameList());

        //dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
    }

    //private void OnDropdownValueChanged()
    //{
        
    //}
}
