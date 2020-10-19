using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderStepManager : MonoBehaviour
{
    public static SliderStepManager SharedInstance = null;

    public int stepSlider_One = 20;
    public int stepSlider_Two = 40;
    public int stepSlider_Three = 60;

    public bool isSliderOneCompleted;
    public bool isSliderTwoCompleted;
    public bool isSliderThreeCompleted;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void StepSlider()
    {


    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
