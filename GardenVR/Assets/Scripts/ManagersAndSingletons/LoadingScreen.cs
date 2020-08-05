using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Code Credits: https://www.windykeep.com/2018/02/15/make-loading-screen-unity/
//Changes made for project: slow load, loading panel, singleton, TMpro
//Call with:
//LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(""));

public class LoadingScreen : Singleton<LoadingScreen>
{
    [SerializeField] private GameObject LoadingPanel = null;
    [SerializeField] private Slider progressBarSlider = null;
    [SerializeField] private TextMeshProUGUI percentLoadedText = null;
    [SerializeField] private bool hideProgressBar = false;
    [SerializeField] private bool hidePercentageText = false;
    private const float MIN_TIME_TO_SHOW = 1f;
    private AsyncOperation currentLoadingOperation = null;
    private bool isLoading = false;
    private float timeElapsed = 0.0f;
    private Animator animator = null;
    private bool didTriggerFadeOutAnimation = false;

    new private void Awake()
    {
        base.Awake();
        Configure();
        Hide();
    }

    private void Configure()
    {
        progressBarSlider.value = 0;
        progressBarSlider.maxValue = 100;
        progressBarSlider.gameObject.SetActive(!hideProgressBar);
        percentLoadedText.gameObject.SetActive(!hidePercentageText);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isLoading)
        {
            SetProgress(currentLoadingOperation.progress);
            if (currentLoadingOperation.isDone && !didTriggerFadeOutAnimation)
            {
                if (animator) animator.SetTrigger("Hide"); else { Hide(); }
                didTriggerFadeOutAnimation = true;
            }
            else
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= MIN_TIME_TO_SHOW)
                {
                    currentLoadingOperation.allowSceneActivation = true;
                }
            }
        }
    }

    private float slowProgress = 0.0f;
    private void SetProgress(float progress)
    {
        if (slowProgress < progress)
        {
            slowProgress += Time.deltaTime;
            progressBarSlider.value = slowProgress;
            if (slowProgress > 1.0f) slowProgress = 1.0f;
        }
        percentLoadedText.text = Mathf.CeilToInt(slowProgress * 100).ToString() + "%";
    }

    public void Show(AsyncOperation loadingOperation)
    {
        LoadingPanel.SetActive(true);
        currentLoadingOperation = loadingOperation;
        currentLoadingOperation.allowSceneActivation = false;
        SetProgress(0f);
        timeElapsed = 0f;
        if (animator) animator.SetTrigger("Show");
        didTriggerFadeOutAnimation = false;
        slowProgress = 0.0f;
        Time.timeScale = 1;
        isLoading = true;
    }

    public void Hide()
    {
        LoadingPanel.SetActive(false);
        currentLoadingOperation = null;
        isLoading = false;
    }
}