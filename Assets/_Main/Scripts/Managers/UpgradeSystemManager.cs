using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Notes:
// PlayerPrefs.GetInt("Upgrade1Level") ve PlayerPrefs.GetInt("Upgrade2Level")'i kontrol ederek upgrade..
//..sisteminin mevcut level'ini cekebilirsiniz.
public class UpgradeSystemManager : MonoBehaviour
{
    [Header("Number of Buttons You Want to Use :")]
    public int upgradeButtonCount = 2;
    [Space(30)]

    public int upgrade1BeginMoney;
    public int upgrade1IncreasingMoneyAmountPerLevel;

    public int upgrade2BeginMoney;
    public int upgrade2IncreasingMoneyAmountPerLevel;

    public int upgrade3BeginMoney;
    public int upgrade3IncreasingMoneyAmountPerLevel;

    public int upgrade4BeginMoney;
    public int upgrade4IncreasingMoneyAmountPerLevel;

    internal GameObject upgrade1GameObject;
    Button upgrade1Button;
    Image upgrade1Image;
    TextMeshProUGUI upgarede1LevelText;
    Image upgrade1MoneyImage;
    TextMeshProUGUI upgrade1MoneyText;

    internal GameObject upgrade2GameObject;
    Button upgrade2Button;
    Image upgrade2Image;
    TextMeshProUGUI upgarede2LevelText;
    Image upgrade2MoneyImage;
    TextMeshProUGUI upgrade2MoneyText;

    internal GameObject upgrade3GameObject;
    Button upgrade3Button;
    Image upgrade3Image;
    TextMeshProUGUI upgarede3LevelText;
    Image upgrade3MoneyImage;
    TextMeshProUGUI upgrade3MoneyText;

    internal GameObject upgrade4GameObject;
    Button upgrade4Button;
    Image upgrade4Image;
    TextMeshProUGUI upgarede4LevelText;
    Image upgrade4MoneyImage;
    TextMeshProUGUI upgrade4MoneyText;

    void Start()
    {
        PlayerPrefs.SetInt("Money", 1000);
        InitObjects();
        SetUpgradeSystem();
        switch (upgradeButtonCount)
        {
            case 1:
                upgrade1GameObject.SetActive(true);
                break;
            case 2:
                upgrade1GameObject.SetActive(true);
                upgrade2GameObject.SetActive(true);
                break;
            case 3:
                upgrade1GameObject.SetActive(true);
                upgrade2GameObject.SetActive(true);
                upgrade3GameObject.SetActive(true);
                break;
            case 4:
                upgrade1GameObject.SetActive(true);
                upgrade2GameObject.SetActive(true);
                upgrade3GameObject.SetActive(true);
                upgrade4GameObject.SetActive(true);
                break;
        }
    }

    void OnClickUpgrade1()
    {
        if (PlayerPrefs.GetInt("Money") < int.Parse(upgrade1MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade1Level", PlayerPrefs.GetInt("Upgrade1Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade1Money"));
        PlayerPrefs.SetInt("Upgrade1Money", (PlayerPrefs.GetInt("Upgrade1Money") + upgrade1IncreasingMoneyAmountPerLevel));

        upgrade1MoneyText.text = PlayerPrefs.GetInt("Upgrade1Money").ToString();
        upgarede1LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade1Level").ToString();

        SetUpgradeSystem();
    }

    void OnClickUpgrade2()
    {
        if (PlayerPrefs.GetInt("Money") < int.Parse(upgrade2MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade2Level", PlayerPrefs.GetInt("Upgrade2Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade2Money"));
        PlayerPrefs.SetInt("Upgrade2Money", (PlayerPrefs.GetInt("Upgrade2Money") + upgrade2IncreasingMoneyAmountPerLevel));

        upgrade2MoneyText.text = PlayerPrefs.GetInt("Upgrade2Money").ToString();
        upgarede2LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade2Level").ToString();

        SetUpgradeSystem();
    }

    void OnClickUpgrade3()
    {
        if (PlayerPrefs.GetInt("Money") < int.Parse(upgrade3MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade3Level", PlayerPrefs.GetInt("Upgrade3Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade3Money"));
        PlayerPrefs.SetInt("Upgrade3Money", (PlayerPrefs.GetInt("Upgrade3Money") + upgrade3IncreasingMoneyAmountPerLevel));

        upgrade3MoneyText.text = PlayerPrefs.GetInt("Upgrade3Money").ToString();
        upgarede3LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade3Level").ToString();

        SetUpgradeSystem();
    }

    void OnClickUpgrade4()
    {
        if (PlayerPrefs.GetInt("Money") < int.Parse(upgrade4MoneyText.text)) return;
        PlayerPrefs.SetInt("Upgrade4Level", PlayerPrefs.GetInt("Upgrade4Level") + 1);
        SetMoney(PlayerPrefs.GetInt("Upgrade4Money"));
        PlayerPrefs.SetInt("Upgrade4Money", (PlayerPrefs.GetInt("Upgrade4Money") + upgrade2IncreasingMoneyAmountPerLevel));

        upgrade4MoneyText.text = PlayerPrefs.GetInt("Upgrade4Money").ToString();
        upgarede4LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade4Level").ToString();

        SetUpgradeSystem();
    }

    void SetUpgradeSystem()
    {
        SetUpgrade1UpgradeSystem();
        SetUpgrade2UpgradeSystem();
        SetUpgrade3UpgradeSystem();
        SetUpgrade4UpgradeSystem();
    }

    void SetUpgrade1UpgradeSystem()
    {
        int moneytext = PlayerPrefs.GetInt("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade1Money"))
        {
            ColorBlock colors = upgrade1Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade1Button.colors = colors;
            upgrade1GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade1Image.color = new Color(1, 1, 1, 1);
            upgrade1MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade1Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade1Button.colors = colors;
            upgrade1GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade1Image.color = new Color(1, 1, 1, 0.6f);
            upgrade1MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade2UpgradeSystem()
    {
        int moneytext = PlayerPrefs.GetInt("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade2Money"))
        {
            ColorBlock colors = upgrade2Button.colors;
            colors.pressedColor = new Color(0.76f, 0.76f, 0.76f, 1);
            upgrade2Button.colors = colors;
            upgrade2GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade2Image.color = new Color(1, 1, 1, 1);
            upgrade2MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade2Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade2Button.colors = colors;
            upgrade2GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade2Image.color = new Color(1, 1, 1, 0.6f);
            upgrade2MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade3UpgradeSystem()
    {
        int moneytext = PlayerPrefs.GetInt("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade3Money"))
        {
            ColorBlock colors = upgrade3Button.colors;
            colors.pressedColor = new Color(0.76f, 0.76f, 0.76f, 1);
            upgrade3Button.colors = colors;
            upgrade3GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade3Image.color = new Color(1, 1, 1, 1);
            upgrade3MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade3Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade3Button.colors = colors;
            upgrade3GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade3Image.color = new Color(1, 1, 1, 0.6f);
            upgrade3MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade4UpgradeSystem()
    {
        int moneytext = PlayerPrefs.GetInt("Money");
        if (moneytext >= PlayerPrefs.GetInt("Upgrade4Money"))
        {
            ColorBlock colors = upgrade4Button.colors;
            colors.pressedColor = new Color(0.76f, 0.76f, 0.76f, 1);
            upgrade4Button.colors = colors;
            upgrade4GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade4Image.color = new Color(1, 1, 1, 1);
            upgrade4MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade4Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade4Button.colors = colors;
            upgrade4GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade4Image.color = new Color(1, 1, 1, 0.6f);
            upgrade4MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetMoney(int number)
    {
        int money = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", money - number);
        transform.Find("MoneyUI").transform.Find("MoneyText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Money").ToString();
    }

    void InitObjects()
    {
        // Upgrade 1
        upgrade1GameObject = transform.Find("UpgradeButtons").transform.Find("Upgrade1").gameObject;
        upgrade1Button = upgrade1GameObject.GetComponent<Button>();
        upgrade1Button.onClick.AddListener(OnClickUpgrade1);
        upgrade1Image = transform.Find("UpgradeButtons").transform.Find("Upgrade1").transform.Find("Image").GetComponent<Image>();
        upgarede1LevelText = transform.Find("UpgradeButtons").transform.Find("Upgrade1").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade1MoneyImage = transform.Find("UpgradeButtons").transform.Find("Upgrade1").transform.Find("Money").GetComponent<Image>();
        upgrade1MoneyText = transform.Find("UpgradeButtons").transform.Find("Upgrade1").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        // Upgrade 2
        upgrade2GameObject = transform.Find("UpgradeButtons").transform.Find("Upgrade2").gameObject;
        upgrade2Button = upgrade2GameObject.GetComponent<Button>();
        upgrade2Button.onClick.AddListener(OnClickUpgrade2);
        upgrade2Image = transform.Find("UpgradeButtons").transform.Find("Upgrade2").transform.Find("Image").GetComponent<Image>();
        upgarede2LevelText = transform.Find("UpgradeButtons").transform.Find("Upgrade2").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade2MoneyImage = transform.Find("UpgradeButtons").transform.Find("Upgrade2").transform.Find("Money").GetComponent<Image>();
        upgrade2MoneyText = transform.Find("UpgradeButtons").transform.Find("Upgrade2").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        // Upgrade 3
        upgrade3GameObject = transform.Find("UpgradeButtons").transform.Find("Upgrade3").gameObject;
        upgrade3Button = upgrade3GameObject.GetComponent<Button>();
        upgrade3Button.onClick.AddListener(OnClickUpgrade3);
        upgrade3Image = transform.Find("UpgradeButtons").transform.Find("Upgrade3").transform.Find("Image").GetComponent<Image>();
        upgarede3LevelText = transform.Find("UpgradeButtons").transform.Find("Upgrade3").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade3MoneyImage = transform.Find("UpgradeButtons").transform.Find("Upgrade3").transform.Find("Money").GetComponent<Image>();
        upgrade3MoneyText = transform.Find("UpgradeButtons").transform.Find("Upgrade3").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        // Upgrade 4
        upgrade4GameObject = transform.Find("UpgradeButtons").transform.Find("Upgrade4").gameObject;
        upgrade4Button = upgrade4GameObject.GetComponent<Button>();
        upgrade4Button.onClick.AddListener(OnClickUpgrade4);
        upgrade4Image = transform.Find("UpgradeButtons").transform.Find("Upgrade4").transform.Find("Image").GetComponent<Image>();
        upgarede4LevelText = transform.Find("UpgradeButtons").transform.Find("Upgrade4").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade4MoneyImage = transform.Find("UpgradeButtons").transform.Find("Upgrade4").transform.Find("Money").GetComponent<Image>();
        upgrade4MoneyText = transform.Find("UpgradeButtons").transform.Find("Upgrade4").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        ConfigureInitializedObjects();
    }

    void ConfigureInitializedObjects()
    {
        //Set Level Text
        if (PlayerPrefs.GetInt("Upgrade1Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade1Level", 1);
            upgarede1LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade1Level").ToString();
        }
        else
        {
            upgarede1LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade1Level").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade2Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade2Level", 1);
            upgarede2LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade2Level").ToString();
        }
        else
        {
            upgarede2LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade2Level").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade3Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade3Level", 1);
            upgarede3LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade3Level").ToString();
        }
        else
        {
            upgarede3LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade3Level").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade4Level") == 0)
        {
            PlayerPrefs.SetInt("Upgrade4Level", 1);
            upgarede4LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade4Level").ToString();
        }
        else
        {
            upgarede4LevelText.text = "Level " + PlayerPrefs.GetInt("Upgrade4Level").ToString();
        }
        
        //Set Money Text
        if (PlayerPrefs.GetInt("Upgrade1Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade1Money", upgrade1BeginMoney);
            upgrade1MoneyText.text = PlayerPrefs.GetInt("Upgrade1Money").ToString();
        }
        else
        {
            upgrade1MoneyText.text = PlayerPrefs.GetInt("Upgrade1Money").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade2Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade2Money", upgrade2BeginMoney);
            upgrade2MoneyText.text = PlayerPrefs.GetInt("Upgrade2Money").ToString();
        }
        else
        {
            upgrade2MoneyText.text = PlayerPrefs.GetInt("Upgrade2Money").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade3Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade3Money", upgrade3BeginMoney);
            upgrade3MoneyText.text = PlayerPrefs.GetInt("Upgrade3Money").ToString();
        }
        else
        {
            upgrade3MoneyText.text = PlayerPrefs.GetInt("Upgrade3Money").ToString();
        }

        if (PlayerPrefs.GetInt("Upgrade4Money") == 0)
        {
            PlayerPrefs.SetInt("Upgrade4Money", upgrade4BeginMoney);
            upgrade4MoneyText.text = PlayerPrefs.GetInt("Upgrade4Money").ToString();
        }
        else
        {
            upgrade4MoneyText.text = PlayerPrefs.GetInt("Upgrade4Money").ToString();
        }
    }
}