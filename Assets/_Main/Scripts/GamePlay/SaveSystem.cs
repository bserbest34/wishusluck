using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == 0)
            {
                PlayerPrefs.SetInt(transform.GetChild(i).name, 1);
            }

            if (PlayerPrefs.GetInt(transform.GetChild(i).name) == 1)
            {
                transform.GetChild(i).transform.Find("NewArea").gameObject.SetActive(false);
                transform.GetChild(i).transform.Find("Game").gameObject.SetActive(true);
            } else
            {
                transform.GetChild(i).transform.Find("NewArea").gameObject.SetActive(true);
                transform.GetChild(i).transform.Find("Game").gameObject.SetActive(false);
            }
        }

        for(int i = 0; i < GameObject.Find("Monies").transform.childCount; i++)
        {
            MoneyDistrubutor item = GameObject.Find("Monies").transform.GetChild(i).GetComponent<MoneyDistrubutor>();
            if (PlayerPrefs.GetInt("Monies1") == 0)
            {
                PlayerPrefs.SetInt("Monies1", 1);
            }
            if(PlayerPrefs.GetInt(item.name) == 1)
            {
                item.isBought = true;
                item.transform.Find("Canvas").Find("Image").Find("Text").gameObject.SetActive(false);
                switch (item.name)
                {
                    case "Monies2":
                        GameObject.Find("Monies").transform.Find("Monies3").gameObject.SetActive(true);
                        break;
                    case "Monies3":
                        GameObject.Find("Monies").transform.Find("Monies4").gameObject.SetActive(true);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                item.isBought = false;
                item.transform.Find("Canvas").Find("Image").Find("Text").gameObject.SetActive(true);
            }
        }
    }
}
