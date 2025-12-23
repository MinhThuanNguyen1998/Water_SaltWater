using System.Collections.Generic;
using UnityEngine;

public class Config
{
    // Path
    public static string StreamingAssetsPath => Application.streamingAssetsPath;
    public const string ElementsData = "ElementsData.json";
    public const string FullElementDetails = "FullElementDetails.json";

   
    public const float WAITING_TIME_TO_PLAY_Temperatur_Rise_EFFECT = 10f;
    public const float WAITING_TIME_TO_PLAY_BOILING_EFFECT = WAITING_TIME_TO_PLAY_Temperatur_Rise_EFFECT + 5f;
    public const float WAITING_TIME_TO_PLAY_CONDENSATION_EFFECT = WAITING_TIME_TO_PLAY_BOILING_EFFECT + 10f;
}

   

