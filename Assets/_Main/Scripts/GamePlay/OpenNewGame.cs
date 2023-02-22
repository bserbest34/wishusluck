using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenNewGame : MonoBehaviour
{
    Button buyNewAreaBtn;
    bool isBought = false;
    public int costValue = 50;

    void Start()
    {
        buyNewAreaBtn = GetComponent<Button>();
        buyNewAreaBtn.onClick.AddListener(BuyNewArea);
    }

    private void Update()
    {
        if (MoneyManager.Instance.money >= costValue)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    void BuyNewArea()
    {
        if (PlayerPrefs.GetInt("Money") >= costValue)
        {
            Vibrations.Succes();
            MoneyManager.Instance.IncreaseMoneyAndWrite(-costValue);
            isBought = true;
            gameObject.SetActive(false);
            transform.parent.Find("Game").gameObject.SetActive(true);
            PlayerPrefs.SetInt(transform.parent.name, 1);
        }
        else
        {
            Vibrations.Failure();
            StartCoroutine(SetRedAlert(buyNewAreaBtn));
        }
    }

    internal IEnumerator SetRedAlert(Button btn)
    {
        btn.gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        btn.gameObject.GetComponent<Image>().color = Color.white;
    }
}
