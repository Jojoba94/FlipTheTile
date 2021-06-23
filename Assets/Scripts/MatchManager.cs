using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private int _timePeriodSeconds = 60;

    private async void Start()
    {
        await CountDown();
    }

    private async Task CountDown()
    {
        for (int i = 0; i < _timePeriodSeconds; i++)
        {
            await Task.Delay(1000);
            //Debug.Log(Time.time);
        }
    }


}
