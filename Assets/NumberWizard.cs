using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Variáveis
    public int max;
    public int min;
    public int guess;
    private bool gameFinished;

    NumberWizard()
    {
        max = 1000;
        min = 1;
        gameFinished = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        UpdateGuess();
        Debug.Log("Number Wizard Game");
        Debug.Log($"Choose a number around {min} and {max}");
        ShowGuessText();
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            PlayerResponse(1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            PlayerResponse(2);
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            PlayerResponse(3);
    }

    private void PlayerResponse(byte k)
    {
        if (k == 3)
        {
            if (gameFinished)
            {
                RestartGame();
                return;
            }

            Debug.Log("I did it! :)");
            Debug.Log("Press ENTER to restart");
            gameFinished = !gameFinished;
            return;
        }

        if (gameFinished)
        {
            return;
        }

        if (k == 1) min = guess;
        else if (k == 2) max = guess;

        UpdateGuess();
        ShowGuessText();
    }

    private void UpdateGuess()
    {
        guess = (max + min) / 2;
    }

    private void ShowGuessText()
    {
        Debug.Log($"You choose {guess}?");
        Debug.Log("Press Up Key if you choose a higher number than my guess, Down Key if lower and Enter if I'm right.");
    }

    private void RestartGame()
    {
        max = 1000;
        min = 1;
        gameFinished = false;
        StartGame();
    }
}
