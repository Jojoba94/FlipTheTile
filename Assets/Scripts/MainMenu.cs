using Assets.Scripts.Utilities;
using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ScreenShade;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    public ReactiveCommand PlayCommand { get; set; }
    public ReactiveCommand QuitCommand { get; set; }

    public ReactiveProperty<bool> CanStart { get; set; } = new ReactiveProperty<bool>(false);

    private Image _image;

    private void Start()
    {
        _ScreenShade.SetActive(false);
        _image = _ScreenShade.GetComponent<Image>();
        BindCommands();
    }

    private void BindCommands()
    {
        PlayCommand = ReactiveCommandExtension.Create(
            async () =>
            {
                _ScreenShade.SetActive(true);
                await FadeIn();
                SceneManager.LoadScene(Stage.SampleScene.ToString());
            }, CanStart);

        PlayCommand.BindTo(_startButton);

        QuitCommand = ReactiveCommandExtension.CreateAndBind(
            () =>
            {
                Debug.Log("Quit");
                Application.Quit();
            }, Observable.Return<bool>(false), _quitButton);
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
