using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UIElements;
using TMPro;
using UnityEngine.Events;
using System.Collections;
using PathCreation.Examples;
using ElephantSDK;

public class UIManager : Singleton<UIManager>
{
    public enum CpiVideoEnum
    {
        CpiVideo,GamePlay
    }
    public enum EndLevelType
    {
        Classic, UnlockNewObject
    }
    [Header("Replaces UI elements")]
    public CpiVideoEnum UI;
    private Button tapToStartBtn;
    private Button tapToRetryBtn;
    private Button tapToContinue;
    private GameObject successPanel;
    private GameObject failPanel;
    private TextMeshProUGUI levelText;
    public UnityAction OnLevelStart;
    public EndLevelType endLevelType;
    public GameObject levelEditorManager;
    static GameObject _levelEditorManager;
    internal bool isGameStarted = false;

    private void OnValidate()
    {
        _levelEditorManager = levelEditorManager;
    }

    void Start()
    {
        CPIVideo();
        levelText = transform.Find("LevelBar").GetComponentInChildren<TextMeshProUGUI>();
        tapToStartBtn = transform.Find("FullscreenButton").GetComponent<Button>();
        failPanel = transform.Find("FullscreenFail").gameObject;
        tapToRetryBtn = failPanel.GetComponentInChildren<Button>();
        successPanel = transform.Find("FullscreenSuccess").gameObject;
        tapToContinue = successPanel.GetComponentInChildren<Button>();
        levelText.SetText("LEVEL " + PlayerPrefs.GetInt("Level", 1).ToString());

        tapToContinue.onClick.AddListener(TapToContinue);
        tapToRetryBtn.onClick.AddListener(TapToRetry);
        tapToStartBtn.onClick.AddListener(TapToStart);

        successPanel.SetActive(false);
        failPanel.SetActive(false);
        tapToStartBtn.gameObject.SetActive(true);
    }

    private void TapToContinue()
    {
        tapToContinue.onClick.RemoveAllListeners();
        MoneyManager.Instance.SaveMoney();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        StartCoroutine(FindObjectOfType<LevelManager>().LoadLevel());
    }

    private void TapToRetry()
    {
        tapToRetryBtn.onClick.RemoveAllListeners();
        StartCoroutine(FindObjectOfType<LevelManager>().LoadLevel());
    }

    private void TapToStart()
    {
        isGameStarted = true;
        tapToStartBtn.onClick.RemoveAllListeners();
        if(FindObjectOfType<UpgradeSystemManager>().enabled)
        {
            FindObjectOfType<UpgradeSystemManager>().upgrade1GameObject.SetActive(false);
            FindObjectOfType<UpgradeSystemManager>().upgrade2GameObject.SetActive(false);
            FindObjectOfType<UpgradeSystemManager>().upgrade3GameObject.SetActive(false);
            FindObjectOfType<UpgradeSystemManager>().upgrade4GameObject.SetActive(false);
        }

        Elephant.LevelStarted(PlayerPrefs.GetInt("Level"));
        if (FindObjectOfType<SwerveInput>() != null)
        {
            FindObjectOfType<SwerveInput>().enabled = true;
            transform.Find("TutorialUI").gameObject.SetActive(true);
            transform.Find("TutorialUI").Find("Swerve").gameObject.SetActive(true);
            StartCoroutine(CloseTutorial());
        }

        if (FindObjectOfType<JoystickControl>() != null)
        {
            FindObjectOfType<JoystickControl>().enabled = true;
            transform.Find("TutorialUI").gameObject.SetActive(true);
            transform.Find("TutorialUI").Find("Drag&Move").gameObject.SetActive(true);
            StartCoroutine(CloseTutorial());
        }


        if (FindObjectOfType<PathFollower>() != null)
        {
            foreach (var item in FindObjectsOfType<PathFollower>())
            {
                item.enabled = true;
            }
            transform.Find("TutorialUI").gameObject.SetActive(true);
            transform.Find("TutorialUI").Find("Swerve").gameObject.SetActive(true);
            StartCoroutine(CloseTutorial());
        }
        tapToStartBtn.gameObject.SetActive(false);
    }

    public void SuccesGame()
    {
        if (!successPanel.activeSelf)
            Elephant.LevelCompleted(PlayerPrefs.GetInt("Level"));
        if (!successPanel.activeSelf)
        {
            ConfigureEndLevelType();
            successPanel.SetActive(true);
            ConfigureSuccessPanel();
        }
    }

    void ConfigureEndLevelType()
    {
        if (successPanel.transform.Find("EndLevel").Find("Unlocks").childCount > PlayerPrefs.GetInt("IndexOfNewObject") &&
            endLevelType == EndLevelType.UnlockNewObject)
        {
            successPanel.transform.Find("EndLevel").gameObject.SetActive(true);
            successPanel.transform.Find("ClassicSuccess").gameObject.SetActive(false);
        }
        else
        {
            successPanel.transform.Find("ClassicSuccess").gameObject.SetActive(true);
            successPanel.transform.Find("EndLevel").gameObject.SetActive(false);
        }
    }

    void ConfigureSuccessPanel()
    {
        if (endLevelType == EndLevelType.Classic || successPanel.transform.Find("EndLevel").Find("Unlocks").childCount <= PlayerPrefs.GetInt("IndexOfNewObject"))
            return;
        int percLevel = PlayerPrefs.GetInt("NewObjectPercentageLevel");
        int indexOfNewObject = PlayerPrefs.GetInt("IndexOfNewObject");
        successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).gameObject.SetActive(true);

        switch (percLevel)
        {
            case 0:
                successPanel.transform.Find("EndLevel").transform.Find("UnlockedPerc").GetComponent<TextMeshProUGUI>().text = "%" + 33 + " UNLOCKED";

                successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).
                    transform.Find("FillArea").transform.Find("Fill").GetComponent<Image>().fillAmount = 0f;
                StartCoroutine(SetFillAmount(successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).
                    transform.Find("FillArea").transform.Find("Fill").GetComponent<Image>(), 33));
                break;
            case 1:
                successPanel.transform.Find("EndLevel").transform.Find("UnlockedPerc").GetComponent<TextMeshProUGUI>().text = "%" + 66 + " UNLOCKED";
                successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).
                    transform.Find("FillArea").transform.Find("Fill").GetComponent<Image>().fillAmount = 0.33f;
                StartCoroutine(SetFillAmount(successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).
                    transform.Find("FillArea").transform.Find("Fill").GetComponent<Image>(), 66));
                break;
            case 2:
                successPanel.transform.Find("EndLevel").transform.Find("UnlockedPerc").GetComponent<TextMeshProUGUI>().text = "%" + 100 + " UNLOCKED";
                successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).
                    transform.Find("FillArea").transform.Find("Fill").GetComponent<Image>().fillAmount = 0.66f;
                StartCoroutine(SetFillAmount(successPanel.transform.Find("EndLevel").Find("Unlocks").GetChild(indexOfNewObject).
                    transform.Find("FillArea").transform.Find("Fill").GetComponent<Image>(), 100));
                break;
            default:
                break;
        }

        if (percLevel == 2)  {
            PlayerPrefs.SetInt("NewObjectPercentageLevel", 0);
            PlayerPrefs.SetInt("IndexOfNewObject", indexOfNewObject + 1);
        } else {
            PlayerPrefs.SetInt("NewObjectPercentageLevel", percLevel + 1);
        }
    }

    IEnumerator SetFillAmount(Image image, float perc)
    {
        while (image.fillAmount < perc / 100)
        {
            yield return new WaitForSeconds(0.02f);
            image.fillAmount += 0.01f;
        }
    }

    public void FailGame()
    {
        if (!failPanel.activeSelf)
            Elephant.LevelFailed(PlayerPrefs.GetInt("Level"));
        failPanel.SetActive(true);
    }

    IEnumerator CloseTutorial()
    {
        yield return new WaitForSeconds(4f);
        transform.Find("TutorialUI").gameObject.SetActive(false);
        transform.Find("TutorialUI").Find("Swerve").gameObject.SetActive(false);
    }

    public void CPIVideo()
    {
        if (UI == CpiVideoEnum.CpiVideo)
        {
            foreach (Transform child in transform)
            {
                if(child.gameObject.GetComponent<CanvasGroup>() == null) continue;
                child.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
        else if (UI == CpiVideoEnum.GamePlay)
        {
            foreach (Transform child in transform){
                if(child.gameObject.GetComponent<CanvasGroup>() == null) continue;
                child.gameObject.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
    }

    internal static void CreateLevelEditorManager()
    {
        if(GameObject.Find("LevelEditorManager(Clone)"))
        {
            Debug.LogWarning("You already have an Level Editor Manager --DliteGames--");
        }else
        {
            Instantiate(_levelEditorManager);
        }
    }
}