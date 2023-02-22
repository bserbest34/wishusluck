using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MoneyDistrubutor : MonoBehaviour
{
    float time = 0;
    int currentMoneyCount = 0;
    public GameObject moneyPrefab;
    bool isDistrubing = false;
    internal bool isBought = false;
    Button buyArea;
    public int costValue = 20;
    public int moneyMultiple = 1;
    int timeChangeable = 4;

    private void Start()
    {
        time = Time.time - 3f;
        buyArea = transform.Find("Canvas").Find("Image").GetComponent<Button>();
        buyArea.onClick.AddListener(BuyArea);
        if (!transform.Find("Canvas").Find("Image").Find("Text").gameObject.activeInHierarchy)
        {
            isBought = true;
        }
    }

    private void Update()
    {
        if (MoneyManager.Instance.money >= costValue)
        {
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
        }

        if (!UIManager.Instance.isGameStarted)
            return;
        if (!isBought)
            return;
        if (isDistrubing)
            return;

        switch (gameObject.name)
        {
            case "Monies1":
                timeChangeable = 3;
                break;
            case "Monies2":
                timeChangeable = 6;
                break;
            case "Monies3":
                timeChangeable = 9;
                break;
            case "Monies4":
                timeChangeable = 12;
                break;
        }
        if (Time.time - time > timeChangeable)
        {
            currentMoneyCount += 1;
            GameObject temp = Instantiate(moneyPrefab, new Vector3(transform.position.x, transform.position.y + currentMoneyCount * 0.3f, transform.position.z), Quaternion.identity, transform);
            temp.GetComponent<MoneyMultipleValue>().moneyMultipleValue = moneyMultiple;
            temp.transform.localPosition = new Vector3(0, currentMoneyCount * 0.5f, 0);
            time = Time.time;
        }
    }

    internal void DistrubuteMoneies(Button btn)
    {
        StartCoroutine(Distrub(btn));
    }

    IEnumerator Distrub(Button btn)
    {
        Vibrations.Soft();
        isDistrubing = true;
        transform.Find("Canvas").Find("Image").GetComponent<Image>().color = Color.white;
        int childCount = transform.childCount - 1;
        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(childCount - i).tag = "Untagged";
            transform.GetChild(childCount - i).DOJump(new Vector3(btn.transform.Find("Monies").transform.position.x,
                btn.transform.Find("Monies").transform.position.y + (btn.GetComponent<ButtonScript>().currrentMoneyCount * 0.5f),
                btn.transform.position.z),
                10, 1, 1f/childCount);
            transform.GetChild(childCount - i).DORotate(new Vector3(0, 90, 0), 1f / childCount);
            transform.GetChild(childCount - i).parent = btn.transform.Find("Monies");
            currentMoneyCount -= 1;
            btn.GetComponent<ButtonScript>().currrentMoneyCount += 1;
            yield return new WaitForSeconds(0.2f);
        }

        isDistrubing = false;
    }

    void BuyArea()
    {
        if (PlayerPrefs.GetInt("Money") >= costValue)
        {
            Vibrations.Selection();
            MoneyManager.Instance.IncreaseMoneyAndWrite(-costValue);
            isBought = true;
            transform.Find("Canvas").Find("Image").Find("Text").gameObject.SetActive(false);
            transform.Find("Canvas").GetComponent<BoxCollider>().enabled = true;
            PlayerPrefs.SetInt(gameObject.name, 1);
            switch (gameObject.name)
            {
                case "Monies2":
                    GameObject.Find("Monies").transform.Find("Monies3").gameObject.SetActive(true);
                    break;
                case "Monies3":
                    GameObject.Find("Monies").transform.Find("Monies4").gameObject.SetActive(true);
                    break;
            }
        }
        else
        {
            Vibrations.Failure();
            StartCoroutine(SetRedAlert(buyArea));
        }
    }

    internal IEnumerator SetRedAlert(Button btn)
    {
        btn.gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        btn.gameObject.GetComponent<Image>().color = Color.white;
    }
}