using UnityEngine;
public class DayTimeScript : MonoBehaviour
{
    #region Fields

    [Header("Daycicle")]
    [SerializeField] private float _dayInSeconds;
    [SerializeField, Range(0.0f, 1.0f)] private float _timeProgress;
    [Header("Day Cicle Controller Setting")]
    [SerializeField] private Light _directionalLightSun;
    [SerializeField] private Light _directionalLightMoon;
    [Header("Day Cicle View Setting")]
    [SerializeField] private Material _daySkybox;
    [SerializeField] private Material _nightSkyBox;
    [SerializeField] private Gradient _directionalLightGradient;
    [SerializeField] private Gradient _ambientColorGradient;

    private Vector3 _defaultAngles;

    #endregion


    #region UnityMethods

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (_directionalLightSun == null || _directionalLightMoon == null)
        {
            print("Отключение режима дня");
            gameObject.SetActive(false);
        }
        else gameObject.SetActive(true);
    }

    private void Start()
    {
        _defaultAngles = _directionalLightSun.transform.localEulerAngles;
    }

    private void Update()
    {
            _timeProgress += Time.deltaTime / _dayInSeconds;
            if (_timeProgress > 1.0f) _timeProgress -= 1.0f;
        if (_timeProgress > 0.5f)
        {
            RenderSettings.fogDensity = 0.003f;
        }
        else RenderSettings.fogDensity = 0.01f;

        if (_timeProgress < 0.5f)
        {
            RenderSettings.sun = _directionalLightMoon;
            RenderSettings.skybox = _nightSkyBox;

        }
        else 
        {
            RenderSettings.sun = _directionalLightSun;
            RenderSettings.skybox = _daySkybox;
        }
        
        DynamicGI.UpdateEnvironment();

        _directionalLightSun.color = _directionalLightGradient.Evaluate(_timeProgress);
        RenderSettings.ambientLight = _ambientColorGradient.Evaluate(_timeProgress);
        RenderSettings.fogColor = _directionalLightGradient.Evaluate(_timeProgress);

        _directionalLightSun.transform.localEulerAngles = new Vector3(360.0f * _timeProgress + 180, 180.0f, 0.0f);

        _directionalLightMoon.transform.localEulerAngles = new Vector3(360.0f * _timeProgress, 180.0f, 0.0f);
    }

    #endregion
}
