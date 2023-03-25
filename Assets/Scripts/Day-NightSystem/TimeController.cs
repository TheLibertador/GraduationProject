using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeController : MonoBehaviour, IDataPersistence
{
    public static TimeController Instance { get; private set; }
    
    
     [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;

    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunLightIntensity;

    [SerializeField]
    private Light moonLight;

    [SerializeField]
    private float maxMoonLightIntensity;

   
    private DateTime m_CurrentTime;

    private TimeSpan m_SunriseTime;

    private TimeSpan m_SunsetTime;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        m_SunriseTime = TimeSpan.FromHours(sunriseHour);
        m_SunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        m_CurrentTime = m_CurrentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        
        if (timeText != null)
        {
            timeText.text = "Current time : " + m_CurrentTime.ToString("HH:mm");
        }
    }
    
    private void RotateSun()
    {
        float sunLightRotation;

        if (m_CurrentTime.TimeOfDay > m_SunriseTime && m_CurrentTime.TimeOfDay < m_SunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(m_SunriseTime, m_SunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(m_SunriseTime, m_CurrentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(m_SunsetTime, m_SunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(m_SunsetTime, m_CurrentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }

    public int GetCurrentDay()
    {
        return m_CurrentTime.Day;
    }

    public int GetCurrentHour()
    {

        return m_CurrentTime.Hour;
    }

    public bool CheckIfSunIsUp()
    {
        if (m_CurrentTime.Hour > sunriseHour && m_CurrentTime.Hour < sunsetHour)
        {
            return true;
        }
        return false;
    }

    public void LoadData(GameData data)
    {
        this.m_CurrentTime = data.totalPlayTime;
    }

    public void SaveData(GameData data)
    {
        data.totalPlayTime = this.m_CurrentTime;
    }

   
}
