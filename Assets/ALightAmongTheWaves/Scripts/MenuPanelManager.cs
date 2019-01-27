using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using RedSpace;

public class MenuPanelManager : MonoBehaviour
{
    protected System.Action onClosedPanel;
    public bool inAnimation = false;
    [SerializeField] protected Canvas canvas;
    [SerializeField] protected CanvasGroup panel;

    [SerializeField] protected Button quitPanelButton;
    [SerializeField] protected Button continueButton;
    [SerializeField] protected Button newGameButton;
    [SerializeField] protected Button optionButton;
    [SerializeField] protected Button quitButton;

    public void OnQuitPanelButtonCliked()
    {
        if (inAnimation) { return; }
        ClosePanel();
    }
    public void OnContinueButtonCliked()
    {
        if (inAnimation) { return; }
        LoadGameScene();
        //Consequence.
    }
    public void OnNewGameButtonCliked()
    {
        if (inAnimation) { return; }
        SaveManager.Instance.CreateNewSave();
        SaveManager.Instance.Save();
        LoadGameScene();

    }
    protected void LoadGameScene()
    {
        GameManager.Instance.LoadScene(GameManager.Scenes.Game);
    }
    public void OnOptionButtonCliked()
    {
        if (inAnimation) { return; }
    }
    public void OnQuitButtonCliked()
    {
        if (inAnimation) { return; }
        QuitTool.Quit();
    }
    protected virtual void Awake()
    {
        OpenPanel();
    }
    protected virtual IEnumerator FadePanelTo(float value, System.Action callback = null)
    {
        inAnimation = true;
        bool opening = ((value < 0.1) ? false : true);
        panel.alpha = ((opening)?0f:1f);
        yield return panel.DOFade(value, 1f).SetEase(((opening)?Ease.InSine:Ease.OutSine)).WaitForCompletion();

        inAnimation = false;
        callback?.Invoke();
    }

    protected void OnPanelOpened()
    {

    }
    public void OpenPanel(System.Action OnClosedPanelCallback = null)
    {
        onClosedPanel = OnClosedPanelCallback;

        //quitPanelButton.gameObject.SetActive(false);
        continueButton.interactable = SaveManager.Instance.haveAValidSave;
        optionButton.interactable = false;
        StartCoroutine(FadePanelTo(1f, OnPanelOpened));
    }
    public void ClosePanel()
    {
        StartCoroutine(FadePanelTo(0f, OnClosedPanel));
    }
    public void OnClosedPanel()
    {
        onClosedPanel?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
