using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagmentSystem : MonoBehaviour
{
    public List<GameObject> cameras = new List<GameObject>();
    internal int unlockedObjectCount = 0;

    public int firstZoomOutObjectCount = 3;
    public int secondZoomOutObjectCount = 6;
    public int thirdZoomOutObjectCount = 9;
    public int fourthZoomOutObjectCount = 12;

    private void Update()
    {
        if(unlockedObjectCount >= fourthZoomOutObjectCount)
        {
            cameras[4].gameObject.SetActive(true);
            cameras[3].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[0].gameObject.SetActive(false);
        }else if (unlockedObjectCount >= thirdZoomOutObjectCount)
        {
            cameras[3].gameObject.SetActive(true);
            cameras[2].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[0].gameObject.SetActive(false);
        }else if (unlockedObjectCount >= secondZoomOutObjectCount)
        {
            cameras[2].gameObject.SetActive(true);
            cameras[1].gameObject.SetActive(false);
            cameras[0].gameObject.SetActive(false);
        }else if (unlockedObjectCount >= firstZoomOutObjectCount)
        {
            cameras[1].gameObject.SetActive(true);
            cameras[0].gameObject.SetActive(false);
        }

        switch (unlockedObjectCount)
        {
            case 1:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 4:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(3).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 5:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(3).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 6:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(3).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(5).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(6).gameObject.SetActive(true);
                break;
            case 7:
                GameObject.Find("WorldCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(3).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(5).gameObject.SetActive(true);
                GameObject.Find("WorldCanvas").transform.GetChild(6).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}