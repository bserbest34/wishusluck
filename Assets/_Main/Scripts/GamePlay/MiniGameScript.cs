using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MiniGameScript : MonoBehaviour
{
    internal GameObject selectedMonies;
    internal Button button1, button2, button3;
    // Start is called before the first frame update
    void Start()
    {
        button1 = transform.Find("Button1").GetComponent<Button>();
        button1.onClick.AddListener(Button1OnClicked);

        if (transform.Find("Button2") != null)
        {
            button2 = transform.Find("Button2").GetComponent<Button>();
            button2.onClick.AddListener(Button2OnClicked);
        }

        if(transform.Find("Button3") != null)
        {
            button3 = transform.Find("Button3").GetComponent<Button>();
            button3.onClick.AddListener(Button3OnClicked);
        }

        FindObjectOfType<CameraManagmentSystem>().unlockedObjectCount += 1;
    }

    void Button1OnClicked()
    {
        if (selectedMonies != null)
        {
            //button1.interactable = false;
            Vibrations.Soft();
            selectedMonies.GetComponent<MoneyDistrubutor>().DistrubuteMoneies(button1);
            foreach (var item in FindObjectsOfType<MiniGameScript>())
            {
                item.selectedMonies = null;
            }
        }else
        {
            Vibrations.Failure();
            StartCoroutine(SetRedAlert(button1));
        }
    }

    void Button2OnClicked()
    {
        if (selectedMonies != null)
        {
            //button2.interactable = false;
            Vibrations.Soft();
            selectedMonies.GetComponent<MoneyDistrubutor>().DistrubuteMoneies(button2);
            foreach (var item in FindObjectsOfType<MiniGameScript>())
            {
                item.selectedMonies = null;
            }
        }else
        {
            Vibrations.Failure();
            StartCoroutine(SetRedAlert(button2));
        }
    }

    void Button3OnClicked()
    {
        if (selectedMonies != null)
        {
            //button3.interactable = false;
            Vibrations.Soft();
            selectedMonies.GetComponent<MoneyDistrubutor>().DistrubuteMoneies(button3);
            foreach (var item in FindObjectsOfType<MiniGameScript>())
            {
                item.selectedMonies = null;
            }
        }
        else
        {
            Vibrations.Failure();
            StartCoroutine(SetRedAlert(button3));
        }
    }

    internal IEnumerator SetRedAlert(Button btn)
    {
        btn.gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        btn.gameObject.GetComponent<Image>().color = btn.GetComponent<ButtonScript>().currrentMoneyCount == 0 ? Color.white : Color.yellow;
    }

    internal void PlayGame()
    {
        int buttonCount = transform.Find("Button3") != null ? 3 : 2;
        int rondomNumber = Random.Range(0, buttonCount);

        if(transform.parent.name == "SlotMachine")
        {
            rondomNumber = Random.Range(0, 5);
            buttonCount = 1;
        }

        switch (buttonCount)
        {
            case 1: //Slot Machine
                StartCoroutine(PlayAnimation(rondomNumber));
                break;
            case 2:
                switch (rondomNumber)
                {
                    case 0:
                        StartCoroutine(PlayAnimation(0));
                        break;
                    case 1:
                        StartCoroutine(PlayAnimation(1));
                        break;
                }
                break;
            case 3:
                switch (rondomNumber)
                {
                    case 0:
                        StartCoroutine(PlayAnimation(0));
                        break;
                    case 1:
                        StartCoroutine(PlayAnimation(1));
                        break;
                    case 2:
                        StartCoroutine(PlayAnimation(2));
                        break;
                    case 3:
                        StartCoroutine(PlayAnimation(3));
                        break;
                    case 4:
                        StartCoroutine(PlayAnimation(4));
                        break;
                }
                break;
        }
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().SetBool("SlotActive", false);

    }

    IEnumerator PlayAnimation(int animationNumber)
    {
        if(transform.parent.name == "SlotMachine")
        {
            GetComponent<Animator>().SetBool("SlotActive", true);
            StartCoroutine(SetFalse());
        }
        GetComponent<Animator>().SetTrigger("Anim_" + animationNumber);

        if (transform.Find("RunRaceArea") != null)
        {
            transform.Find("RunRaceArea").Find("Character@Slow Run").GetComponent<Animator>().enabled = true;
            transform.Find("RunRaceArea").Find("Character@Slow Run (1)").GetComponent<Animator>().enabled = true;
            transform.Find("RunRaceArea").Find("Character@Slow Run (2)").GetComponent<Animator>().enabled = true;
        }

        switch (transform.parent.name)
        {
            case "HorseRace":
                yield return new WaitForSeconds(7.2f);
                break;
            case "Rulet":
                yield return new WaitForSeconds(7.5f);
                break;
            case "HumanRace":
                yield return new WaitForSeconds(7.3f);
                break;
            case "SlotMachine":
                yield return new WaitForSeconds(7f);
                break;
            case "Football":
                yield return new WaitForSeconds(1.5f);
                break;
            case "CarRace":
                yield return new WaitForSeconds(6.8f);
                break;
            case "Dice":
                yield return new WaitForSeconds(3.5f);
                break;
            default:
                yield return new WaitForSeconds(7f);
                break;
        }
        if (transform.Find("RunRaceArea") != null)
        {
            transform.Find("RunRaceArea").Find("Character@Slow Run").GetComponent<Animator>().enabled = false;
            transform.Find("RunRaceArea").Find("Character@Slow Run (1)").GetComponent<Animator>().enabled = false;
            transform.Find("RunRaceArea").Find("Character@Slow Run (2)").GetComponent<Animator>().enabled = false;
        }
        if (transform.parent.name == "SlotMachine")
        {
            SetMoneyToUI(animationNumber, true);
        }else
        {
            SetMoneyToUI(animationNumber);
        }
    }

    void SetMoneyToUI(int animationNumber, bool isSlot = false)
    {
        if(isSlot)
        {
            if (animationNumber == 3 || animationNumber == 4)
            {
                if (button1 != null)
                {
                    for (int i = 0; i < button1.transform.Find("Monies").childCount; i++)
                    {
                        Destroy(button1.transform.Find("Monies").GetChild(button1.transform.Find("Monies").childCount - 1 - i).gameObject);
                    }
                }

                button1.GetComponent<Button>().interactable = true;
                button1.GetComponent<Image>().color = Color.white;
                button1.GetComponent<ButtonScript>().currrentMoneyCount = 0;
                button1.GetComponent<ButtonScript>().isPlayingAnimation = false;
                button1.GetComponent<Button>().interactable = true;
                return;
            }
            else
            {
                Vibrations.Succes();
                button1.transform.Find("Monies").transform.DOShakeScale(2f, 5, 20, 90);
                button1.transform.Find("Monies").transform.DOShakePosition(2f, 5, 20, 90);
                button1.transform.Find("Monies").transform.DOShakeRotation(2f, 5, 20, 90);
                MoneyManager.Instance.CreateMoney(button1.GetComponent<ButtonScript>().realMoneyCount5x,
                    button1.GetComponent<ButtonScript>().realMoneyCount20x,
                    button1.GetComponent<ButtonScript>().realMoneyCount100x,
                    button1.GetComponent<ButtonScript>().realMoneyCount500x,
                    true, button1.transform.position, button1);
                StartCoroutine(SetColorfulToButton(button1));
                Vibrations.Succes();
                return;
            }
        }

        switch (animationNumber)
        {
            case 0:

                if (button2 != null)
                {
                    for (int i = 0; i < button2.transform.Find("Monies").childCount; i++)
                    {
                        Destroy(button2.transform.Find("Monies").GetChild(button2.transform.Find("Monies").childCount - 1 - i).gameObject);
                    }
                }

                if (button3 != null)
                {
                    for (int i = 0; i < button3.transform.Find("Monies").childCount; i++)
                    {
                        Destroy(button3.transform.Find("Monies").GetChild(button3.transform.Find("Monies").childCount - 1 - i).gameObject);
                    }
                }
                Vibrations.Succes();
                button1.transform.Find("Monies").transform.DOShakeScale(2f, 5, 20, 90);
                button1.transform.Find("Monies").transform.DOShakePosition(2f, 5, 20, 90);
                button1.transform.Find("Monies").transform.DOShakeRotation(2f, 5, 20, 90);
                MoneyManager.Instance.CreateMoney(button1.GetComponent<ButtonScript>().realMoneyCount5x,
                    button1.GetComponent<ButtonScript>().realMoneyCount20x,
                    button1.GetComponent<ButtonScript>().realMoneyCount100x,
                    button1.GetComponent<ButtonScript>().realMoneyCount500x,
                    true, button1.transform.position, button1);
                StartCoroutine(SetColorfulToButton(button1));
                Vibrations.Succes();
                break;
            case 1:

                for (int i = 0; i < button1.transform.Find("Monies").childCount; i++)
                {
                    Destroy(button1.transform.Find("Monies").GetChild(button1.transform.Find("Monies").childCount - 1 - i).gameObject);
                }

                if (button3 != null)
                {
                    for (int i = 0; i < button3.transform.Find("Monies").childCount; i++)
                    {
                        Destroy(button3.transform.Find("Monies").GetChild(button3.transform.Find("Monies").childCount - 1 - i).gameObject);
                    }
                }
                Vibrations.Succes();
                button2.transform.Find("Monies").transform.DOShakeScale(2f, 5, 20, 90);
                button2.transform.Find("Monies").transform.DOShakePosition(2f, 5, 20, 90);
                button2.transform.Find("Monies").transform.DOShakeRotation(2f, 5, 20, 90);
                MoneyManager.Instance.CreateMoney(button2.GetComponent<ButtonScript>().realMoneyCount5x,
                    button2.GetComponent<ButtonScript>().realMoneyCount20x,
                    button2.GetComponent<ButtonScript>().realMoneyCount100x,
                    button2.GetComponent<ButtonScript>().realMoneyCount500x,
                    true, button2.transform.position, button2);
                StartCoroutine(SetColorfulToButton(button2));
                Vibrations.Succes();
                break;
            case 2:

                for (int i = 0; i < button1.transform.Find("Monies").childCount; i++)
                {
                    Destroy(button1.transform.Find("Monies").GetChild(button1.transform.Find("Monies").childCount - 1 - i).gameObject);
                }

                if (button2 != null)
                {
                    for (int i = 0; i < button2.transform.Find("Monies").childCount; i++)
                    {
                        Destroy(button2.transform.Find("Monies").GetChild(button2.transform.Find("Monies").childCount - 1 - i).gameObject);
                    }
                }
                Vibrations.Succes();
                button3.transform.Find("Monies").transform.DOShakeScale(2f, 5, 20, 90);
                button3.transform.Find("Monies").transform.DOShakePosition(2f, 5, 20, 90);
                button3.transform.Find("Monies").transform.DOShakeRotation(2f, 5, 20, 90); MoneyManager.Instance.CreateMoney(button3.GetComponent<ButtonScript>().realMoneyCount5x,
                     button3.GetComponent<ButtonScript>().realMoneyCount20x,
                     button3.GetComponent<ButtonScript>().realMoneyCount100x,
                     button3.GetComponent<ButtonScript>().realMoneyCount500x,
                     true, button3.transform.position, button3);
                StartCoroutine(SetColorfulToButton(button3));
                Vibrations.Succes();
                break;
            default:

                button1.GetComponent<Image>().color = Color.white;
                button1.GetComponent<ButtonScript>().currrentMoneyCount = 0;
                button1.GetComponent<ButtonScript>().isPlayingAnimation = false;

                if (button3 != null)
                {
                    button3.GetComponent<Image>().color = Color.white;
                    button3.GetComponent<ButtonScript>().currrentMoneyCount = 0;
                    button3.GetComponent<ButtonScript>().isPlayingAnimation = false;
                }

                if (button2 != null)
                {
                    button2.GetComponent<Image>().color = Color.white;
                    button2.GetComponent<ButtonScript>().currrentMoneyCount = 0;
                    button2.GetComponent<ButtonScript>().isPlayingAnimation = false;
                }


                button1.GetComponent<Button>().interactable = true;

                if (button2 != null)
                {
                    button2.GetComponent<Button>().interactable = true;
                }

                if (button3 != null)
                {
                    button3.GetComponent<Button>().interactable = true;
                }
                break;
        }
    }

    IEnumerator SetColorfulToButton(Button btn)
    {
        btn.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.2f);

        btn.GetComponent<Image>().color = Color.blue;
        yield return new WaitForSeconds(0.2f);


        btn.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.2f);

        btn.GetComponent<Image>().color = Color.cyan;
        yield return new WaitForSeconds(0.2f);


        btn.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.2f);

        btn.GetComponent<Image>().color = Color.yellow;
        yield return new WaitForSeconds(0.2f);

        btn.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.2f);

        transform.Find("Button1").GetComponent<Image>().color = Color.white;
        transform.Find("Button1").GetComponent<ButtonScript>().currrentMoneyCount = 0;
        transform.Find("Button1").GetComponent<ButtonScript>().isPlayingAnimation = false;

        if (transform.Find("Button2") != null)
        {
            transform.Find("Button2").GetComponent<Image>().color = Color.white;
            transform.Find("Button2").GetComponent<ButtonScript>().currrentMoneyCount = 0;
            transform.Find("Button2").GetComponent<ButtonScript>().isPlayingAnimation = false;
        }

        if (transform.Find("Button3") != null)
        {
            transform.Find("Button3").GetComponent<Image>().color = Color.white;
            transform.Find("Button3").GetComponent<ButtonScript>().currrentMoneyCount = 0;
            transform.Find("Button3").GetComponent<ButtonScript>().isPlayingAnimation = false;
        }

        yield return new WaitForSeconds(1f);
        transform.Find("Button1").GetComponent<Button>().interactable = true;

        if (transform.Find("Button2") != null)
        {
            transform.Find("Button2").GetComponent<Button>().interactable = true;
        }

        if (transform.Find("Button3") != null)
        {
            transform.Find("Button3").GetComponent<Button>().interactable = true;
        }

        if(button1.transform.Find("Monies").Find("Monies(Clone)") != null)
        {
            Destroy(button1.transform.Find("Monies").Find("Monies(Clone)"));
        }

        if (button2 != null && button2.transform.Find("Monies").Find("Monies(Clone)") != null)
        {
            Destroy(button2.transform.Find("Monies").Find("Monies(Clone)"));
        }

        if (button3 != null && button3.transform.Find("Monies").Find("Monies(Clone)") != null)
        {
            Destroy(button3.transform.Find("Monies").Find("Monies(Clone)"));
        }
    }
}
