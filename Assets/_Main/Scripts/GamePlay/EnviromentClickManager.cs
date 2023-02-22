using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnviromentClickManager : MonoBehaviour
{
    void Update()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            if (raycastHit.collider.tag == "Money")
            {
                Vibrations.Light();
                foreach (var item in GameObject.FindGameObjectsWithTag("MoneyInstantiateAreas"))
                {
                    item.transform.Find("Canvas").Find("Image").GetComponent<Image>().color = Color.white;
                }
                raycastHit.collider.transform.parent.transform.Find("Canvas").Find("Image").GetComponent<Image>().color = Color.green;

                foreach (var item in FindObjectsOfType<MiniGameScript>())
                {
                    item.selectedMonies = raycastHit.collider.transform.parent.gameObject;
                }
            }
        }
    }
}