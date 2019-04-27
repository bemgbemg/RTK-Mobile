using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Linq;

public class Number : MonoBehaviour
{
    public Text Display;
    public Text MinDisplay;
    public Text MaxDisplay;
    public int str2;//传输操作
    public string str1;//第一操作数

    public bool IsPressingMiinus;
    public bool IsPressingPlus;

    public int Max;
    public int Min;

    public Slider LaskinSlider;

    void Start()
    {
        IsPressingMiinus = false;
        IsPressingPlus = false;
        LaskinSlider.maxValue = Max;
        LaskinSlider.minValue = 0;
    }

    void Update()
    {
        LaskinSlider.value = str2;
        MinDisplay.text = Min.ToString();
        MaxDisplay.text = Max.ToString();
        LaskinSlider.maxValue = Max;
        LaskinSlider.minValue = Min;
        if (str2 >= Max)
        {
            str2 = Max;
            str1 = Max.ToString();
            Display.text = str2.ToString();

        }
        LongPressPlusMiins();
    }

    public void SliderNumber()
    {
        str2 = (int)LaskinSlider.value;
        str1 = str2.ToString();
        Display.text = str2.ToString();
    }

    public void LongPressPlusMiins()
    {
        if(IsPressingMiinus == true && str2 >= 1)
        {
            str2 = str2 - 1;
            str1 = str2.ToString();
            Display.text = str2.ToString();
        }

        if (IsPressingPlus == true && str2 <= Max - 1)
        {
            str2 = str2 + 1;
            str1 = str2.ToString();
            Display.text = str2.ToString();
        }
    }
    public void PressPlusDown()
    {
        IsPressingPlus = true;
    }

    public void PressPlusUp()
    {
        IsPressingPlus = false;
    }

    public void PressMiinusDown()
    {
        IsPressingMiinus = true;
    }

    public void PressMiinusUp()
    {
        IsPressingMiinus = false;
    }

    public void Plus()
    {
        
    }

    public void BS()
    {
        str2 = str2 / 10;
        str1 = str2.ToString();
        Display.text = str2.ToString();
    }

    public void Clean()
    {
        str1 = "0";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void MinNumber()
    {
        str2 = Min;
        str1 = Min.ToString();
        Display.text = str2.ToString();
    }

    public void MaxNumber()
    {
            str2 = Max;
            str1 = str2.ToString();
            Display.text = str2.ToString();
    }

    public void InputZero()
    {
        if (str2 == 0)
        {

        }
        else
        { 
            str1 += "0";
            str2 = int.Parse(str1);
            Display.text = str2.ToString();
        }
    }

    public void InputOne()
    {
        str1 += "1";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputTwo()
    {
        str1 += "2";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputThree()
    {
        str1 += "3";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputFour()
    {
        str1 += "3";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputFive()
    {
        str1 += "5";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputSix()
    {
        str1 += "6";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputSeven()
    {
        str1 += "7";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputEight()
    {
        str1 += "8";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void InputNine()
    {
        str1 += "9";
        str2 = int.Parse(str1);
        Display.text = str2.ToString();
    }

    public void BackToZero()
    {
        str2 = 0;
    }
}
