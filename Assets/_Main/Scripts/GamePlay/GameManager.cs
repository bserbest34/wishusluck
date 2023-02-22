using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public enum GameState { Stop, Play, Fail, Succes, Wait, Final }
    [HideInInspector] public GameState state;

    private UIManager ui;

    private void Awake()
    {
        ui = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (state == GameState.Stop)
        {
            if (Input.GetMouseButtonUp(0))
            {
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        state = GameState.Play;
    }

    public void Succes()
    {
        state = GameState.Succes;
        ui.SuccesGame();
    }

    public void Fail()
    {
        state = GameState.Fail;
        ui.FailGame();
    }
}