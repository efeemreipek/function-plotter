using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private Graph graph;
    [SerializeField] private Slider incSlider;
    [SerializeField] private TMP_Text incText;  

    public TMP_Dropdown dropdown;


    private void Awake()
    {
        dropdown.AddOptions(graph.GetFunctionNameList());

        incText.text = (incSlider.value / 100).ToString();
    }

    private void Update()
    {
        incText.text = (incSlider.value / 100).ToString();
    }

    public float ReturnIncrementValueFromSlider() => (incSlider.value / 100);   

}
