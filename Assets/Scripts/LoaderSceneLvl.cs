using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderSceneLvl : MonoBehaviour
{
    [Header("Ссылки")]
    public RawImage _rawImage;
    public TextMeshProUGUI _loadingText;

    [SerializeField] private float _speed = 2f;
    [SerializeField] private Vector3 _startPosition = new Vector3(0, -1108, -766);
    [SerializeField] private Vector3 _targetPosition = new Vector3(0, 0, -766);
    [SerializeField] private float _fadeSpeed = 2f;
    [SerializeField] private float _pulseSpeed = 2f;
    [SerializeField] private float _minAlpha = 0.2f;
    [SerializeField] private float _maxAlpha = 0.9f;
    [SerializeField] private float _minLoadTime = 3f; // ровно 3 секунды

    public void PlayIntro()
    {
        StartCoroutine(TransformP());
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator TransformP() //это тип метода
    {
        float fadeT = 0f;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * _speed;
            _rawImage.transform.localPosition = Vector3.Lerp(_startPosition, _targetPosition, t);
            yield return null; //это ждет каждый кадр
        }
        while (fadeT < 1)
        {
            fadeT += Time.deltaTime * _fadeSpeed;
            _loadingText.alpha = fadeT;
            yield return null;
        }
        while (true)
        {
            if (_loadingText.alpha >= 0.7f)
            {
                for (float i = _loadingText.alpha; i >= _minAlpha; i -= Time.deltaTime * _pulseSpeed)
                {
                    _loadingText.alpha = i;
                    yield return null;
                }
                _loadingText.alpha = _minAlpha;
            }
            else
            {
                for (float i = _loadingText.alpha; i <= _maxAlpha; i += Time.deltaTime * _pulseSpeed)
                {
                    _loadingText.alpha = i;
                    yield return null;
                }
                _loadingText.alpha = _maxAlpha;
            }
        }
        /*
        float pulseT = 0f;
        while (true)
        {
            pulseT += Time.deltaTime * _pulseSpeed;
            float curtAlpha = _minAlpha + Mathf.PingPong(pulseT, _maxAlpha - _minAlpha); //диап
            _loadingText.alpha = curtAlpha;

        }
        */
    }

    private IEnumerator LoadSceneRoutine()
    {
        // Начинаем грузить сцену в фоне, но не даём ей активироваться
        AsyncOperation op = SceneManager.LoadSceneAsync("Lvl");
        op.allowSceneActivation = false;

        float t = 0f;
        // Ждём минимум 3 секунды И пока сцена не будет готова (progress >= 0.9)
        while (t < _minLoadTime || op.progress < 0.9f)
        {
            t += Time.unscaledDeltaTime; // unscaled — чтобы пауза (timeScale=0) не тормозила загрузку
            yield return null;
        }

        // Разрешаем переход
        op.allowSceneActivation = true;
    }

    public void LoaderScene()
    {
        SceneManager.LoadScene("Lvl");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}