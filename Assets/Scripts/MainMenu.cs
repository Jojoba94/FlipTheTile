using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ScreenShade;
    [SerializeField] private AnimationCurve _curve;

    private Image _image;

    private void Start()
    {
        _ScreenShade.SetActive(false);
        _image = _ScreenShade.GetComponent<Image>();
    }

    public async void Play()
    {
        _ScreenShade.SetActive(true);
        await FadeIn();
        SceneManager.LoadScene(Stage.SampleScene.ToString());
    }

    private async Task FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _curve.Evaluate(t));
            await Task.Delay(1);
        }
    }

    private async UniTask FadeOut()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _curve.Evaluate(t));
            await UniTask.Delay(1);
        }
    }

}
