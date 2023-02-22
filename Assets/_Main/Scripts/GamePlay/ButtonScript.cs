using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class ButtonScript : MonoBehaviour
{
    internal int currrentMoneyCount = 0;
    bool isFilled = false;
    bool isFirst = false;
    internal bool isPlayingAnimation = false;
    float time = 0;

    internal int realMoneyCount5x = 0;
    internal int realMoneyCount20x = 0;
    internal int realMoneyCount100x = 0;
    internal int realMoneyCount500x = 0;

    private void Update()
    {
        if (isPlayingAnimation)
        {
            realMoneyCount5x = 0;
            realMoneyCount20x = 0;
            realMoneyCount100x = 0;
            realMoneyCount500x = 0;

            foreach (var item in transform.Find("Monies").GetComponentsInChildren<MoneyMultipleValue>())
            {
                switch (item.moneyMultipleValue)
                {
                    case 5:
                        realMoneyCount5x += 1;
                        break;
                    case 20:
                        realMoneyCount20x += 1;
                        break;
                    case 100:
                        realMoneyCount100x += 1;
                        break;
                    case 500:
                        realMoneyCount500x += 1;
                        break;
                }
            }
            return;
        }


        if(currrentMoneyCount > 0)
        {
            GetComponent<Image>().color = Color.yellow;
            if (transform.parent.Find("Bar").GetComponent<ProceduralImage>().fillAmount == 0)
            {
                isFirst = true;
            }

            realMoneyCount5x = 0;
            realMoneyCount20x = 0;
            realMoneyCount100x = 0;
            realMoneyCount500x = 0;

            foreach (var item in transform.Find("Monies").GetComponentsInChildren<MoneyMultipleValue>())
            {
                switch (item.moneyMultipleValue)
                {
                    case 5:
                        realMoneyCount5x += 1;
                        break;
                    case 20:
                        realMoneyCount20x += 1;
                        break;
                    case 100:
                        realMoneyCount100x += 1;
                        break;
                    case 500:
                        realMoneyCount500x += 1;
                        break;
                }
            }

            if (!isFirst)
                return;


            if (!isFilled)
            {
                time = Time.time;
            }
            isFilled = true;
            if (Time.time - time > 0.05f)
            {
                transform.parent.Find("Bar").GetComponent<ProceduralImage>().fillAmount += 0.01f;
                time = Time.time;
                if(transform.parent.Find("Bar").GetComponent<ProceduralImage>().fillAmount == 1)
                {
                    DestroyMonies();
                    transform.parent.Find("Bar").GetComponent<ProceduralImage>().fillAmount = 0;
                    isFilled = false;
                }
            }
        }else
        {
            realMoneyCount5x = 0;
            realMoneyCount20x = 0;
            realMoneyCount100x = 0;
            realMoneyCount500x = 0;
        }
    }

    void DestroyMonies()
    {
        transform.parent.Find("Button1").GetComponent<Button>().interactable = false;

        if (transform.parent.Find("Button2") != null)
        {
            transform.parent.Find("Button2").GetComponent<Button>().interactable = false;
        }

        if (transform.parent.Find("Button3") != null)
        {
            transform.parent.Find("Button3").GetComponent<Button>().interactable = false;
        }

        transform.parent.Find("Button1").GetComponent<ButtonScript>().isPlayingAnimation = true;

        if (transform.parent.Find("Button2") != null)
        {
            transform.parent.Find("Button2").GetComponent<ButtonScript>().isPlayingAnimation = true;
        }

        if (transform.parent.Find("Button3") != null)
        {
            transform.parent.Find("Button3").GetComponent<ButtonScript>().isPlayingAnimation = true;
        }


        //for (int i = 0; i < transform.parent.Find("Button1").Find("Monies").childCount; i++)
        //{
        //    Destroy(transform.parent.Find("Button1").Find("Monies").GetChild(transform.parent.Find("Button1").Find("Monies").childCount - 1 - i).gameObject);
        //}

        //if (transform.parent.Find("Button2") != null)
        //{
        //    for (int i = 0; i < transform.parent.Find("Button2").Find("Monies").childCount; i++)
        //    {
        //        Destroy(transform.parent.Find("Button2").Find("Monies").GetChild(transform.parent.Find("Button2").Find("Monies").childCount - 1 - i).gameObject);
        //    }
        //}

        //if (transform.parent.Find("Button3") != null)
        //{
        //    for (int i = 0; i < transform.parent.Find("Button3").Find("Monies").childCount; i++)
        //    {
        //        Destroy(transform.parent.Find("Button3").Find("Monies").GetChild(transform.parent.Find("Button3").Find("Monies").childCount - 1 - i).gameObject);
        //    }
        //}
        //StartCoroutine(DestroyBugMonies());
        transform.parent.GetComponent<MiniGameScript>().PlayGame();
    }

    IEnumerator DestroyBugMonies()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < transform.parent.Find("Button1").Find("Monies").childCount; i++)
        {
            Destroy(transform.parent.Find("Button1").Find("Monies").GetChild(transform.parent.Find("Button1").Find("Monies").childCount - 1 - i).gameObject);
        }

        if (transform.parent.Find("Button2") != null)
        {
            for (int i = 0; i < transform.parent.Find("Button2").Find("Monies").childCount; i++)
            {
                Destroy(transform.parent.Find("Button2").Find("Monies").GetChild(transform.parent.Find("Button2").Find("Monies").childCount - 1 - i).gameObject);
            }
        }

        if (transform.parent.Find("Button3") != null)
        {
            for (int i = 0; i < transform.parent.Find("Button3").Find("Monies").childCount; i++)
            {
                Destroy(transform.parent.Find("Button3").Find("Monies").GetChild(transform.parent.Find("Button3").Find("Monies").childCount - 1 - i).gameObject);
            }
        }
    }
}
