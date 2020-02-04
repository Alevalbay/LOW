using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTime : MonoBehaviour
{
    private const int TIMESCALE = 255;

   public TMP_Text clockText;
   public TMP_Text dayText;
   public TMP_Text seasonText;
   public TMP_Text yearText;
   public int hour;

    private double minute,day,second,month,year;
    void Start()
    {
        hour=12;
        month = 4;
        day = 1;
        year = 1445;
        CalculateSeason();
    }


    void Update()
    {
        CalculateTime();
    }
    public void TextCallFunction()
    {
        dayText.text = ("Day " + day);
        if (hour < 10)
        {
            clockText.text = ("Time:0" + hour + ":" + minute);

        }
        else if (minute < 10)
        {
            clockText.text = ("Time:" + hour + ":0" + minute);

        }
        else if (minute < 10 && hour < 10)
        {
            clockText.text = ("Time:0" + hour + ":0" + minute);

        }
        else
        {
            clockText.text = ("Time:" + hour + ":" + minute);
        }

        yearText.text = ("Year" + year);

    }
    public void CalculateTime()
    {
        second += Time.deltaTime * TIMESCALE;

        if (second >= 60)
        {
            minute++;
            second = 0;
            TextCallFunction();
        }
        else if (minute >= 60)
        {
            hour++;
            minute = 0;
            TextCallFunction();
        }
        else if (hour >= 24)
        {
            day++;
            hour = 0;
            TextCallFunction();
        }
        else if (day > 28)
        { 
            CalculateMonth();
        }
        else if (month>=12)
        {
            month = 1;
            year++;
            TextCallFunction();
            CalculateSeason();
        }
    }
    public void CalculateMonth()
    {
        if(month%2==1)
        {
            if (day >= 32)
                month++;
                day = 1;
            TextCallFunction();
            CalculateSeason();
        }
        else
        {
            if (day >= 31)
                month++;
            day = 1;
            TextCallFunction();
            CalculateSeason();
        }

    }
    public void CalculateSeason()
    {
        if(month<=3 && month>=1)
        {
            seasonText.text = "Winter";
        }
        else if(month>=4 && month<=6)
        {
            seasonText.text = "Spring";
        }
        else if (month >= 7 && month <= 9)
        {
            seasonText.text = "Summer";
        }
        else if (month >=10 && month <=12)
        {
            seasonText.text = "Autumn";
        }
    }
}
