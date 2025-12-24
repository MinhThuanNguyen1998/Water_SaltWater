using System.Collections.Generic;
using UnityEngine;

public class Config
{
    //Text Slider
    public const string Slider_Value = "Thời gian sôi:";
    public const string Unit_Time = " s";


    public static float TemperatureRiseTime  { get; private set; } = 10f;
    public static float BoilingTime { get; private set; }
    public static float CondensationTime { get; private set; }

    public static void SetTemperatureRiseTime(float value)
    {
        TemperatureRiseTime = value;
        BoilingTime = TemperatureRiseTime + 2f;
        CondensationTime = BoilingTime;
    }
}

   

