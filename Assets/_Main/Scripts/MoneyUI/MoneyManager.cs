using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private GameObject moneyObject;
    private List<GameObject> moneyList;
    private int moneyPoolCount = 30;

    [SerializeField] private Transform moneyTargetInUI;
    [SerializeField] private TextMeshProUGUI moneyText;

    [HideInInspector] public int money;

    private int moneyObjectValue = 25;

    private Camera camera;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
            moneyText.text = money.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
            money = 0;
        }

        InstantiateMoneyPool();

        camera = Camera.main;
    }

    private void InstantiateMoneyPool()
    {
        moneyList = new List<GameObject>();

        for (int i = 0; i < moneyPoolCount; i++)
        {
            GameObject money = Instantiate(moneyObject);
            money.transform.SetParent(transform);
            money.SetActive(false);

            moneyList.Add(money);
        }
    }

    public void CreateMoney(int besXcount, int yirmiXcount, int yuzXcount, int besyuzXcount, bool saveMoneyImmediately, Vector3 position, Button btn) // Use this
    {
        //float c = count;
        //if(count > 2)
        //{
        //    count = (int)(Math.Ceiling(c / 2));
        //    Debug.Log(count);
        //}
        position = camera.WorldToScreenPoint(position);

        StartCoroutine(SendMoney(besXcount, yirmiXcount, yuzXcount, besyuzXcount, position, saveMoneyImmediately, btn));
    }

    IEnumerator SendMoney(int besXcount, int yirmiXcount, int yuzXcount, int besyuzXcount, Vector3 position, bool saveMoney, Button btn)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < btn.transform.Find("Monies").childCount; i++)
        {
            Destroy(btn.transform.Find("Monies").GetChild(btn.transform.Find("Monies").childCount - 1 - i).gameObject);
        }

        for (int i = 0; i < besXcount; i++)
        {
            StartCoroutine(CreateMoneyInUI(i * 0.05f, position, saveMoney, 5));
        }
        yield return new WaitForSeconds(besXcount * 0.05f);
        for (int i = 0; i < yirmiXcount; i++)
        {
            StartCoroutine(CreateMoneyInUI(i * 0.05f, position, saveMoney, 20));
        }
        yield return new WaitForSeconds(yirmiXcount * 0.05f);
        for (int i = 0; i < yuzXcount; i++)
        {
            StartCoroutine(CreateMoneyInUI(i * 0.05f, position, saveMoney, 100));
        }
        yield return new WaitForSeconds(yuzXcount * 0.05f);
        for (int i = 0; i < besyuzXcount; i++)
        {
            StartCoroutine(CreateMoneyInUI(i * 0.05f, position, saveMoney, 500));
        }

        //for (int i = 0; i < count; i++)
        //{
        //    StartCoroutine(CreateMoneyInUI(i * 0.05f, position, saveMoney));
        //}
    }


    private IEnumerator CreateMoneyInUI(float time, Vector3 position, bool saveMoney, int value)
    {
        yield return new WaitForSeconds(time);

        GameObject money = moneyList[0];
        money.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "+" + value.ToString();
        money.SetActive(true);
        money.transform.position = position;
        money.SetActive(true);
        moneyList.RemoveAt(0);

        money.transform.DOMove(moneyTargetInUI.position, 1f).OnComplete(() =>
        {
            if (saveMoney)
                SaveMoney();

            money.SetActive(false);
            moneyList.Add(money);
            IncreaseMoneyAndWrite(value);
        });
    }

    public void IncreaseMoneyAndWrite(int addingMoney)
    {
        money += addingMoney;
        moneyText.text = money.ToString();
        PlayerPrefs.SetInt("Money", money);
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", money);
    }
}