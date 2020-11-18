using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ScreenShade;
    [SerializeField] private AnimationCurve curve;

    private Image _image;

    private void Start()
    {
        _ScreenShade.SetActive(false);
        _image = _ScreenShade.GetComponent<Image>();
    }

    public async void Play()
    {
        _ScreenShade.SetActive(true);
        StartCoroutine(FadeIn());
        await UniTask.Delay(700);
        _ScreenShade.SetActive(false);
    }

    private IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, a);
            yield return 0;
        }
    }

    private IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, a);
            yield return 0;
        }
    }

}
