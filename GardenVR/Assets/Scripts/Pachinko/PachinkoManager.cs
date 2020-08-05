using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PachinkoManager : Singleton<PachinkoManager>
{
    [SerializeField] GameObject EndScreen = null;
    [SerializeField] GameObject PauseScreen = null;
    [SerializeField] TextMeshProUGUI ScoreDisplay = null;
    [SerializeField] TextMeshProUGUI PickupsCollectedDisplay = null;
    [SerializeField] GameObject GamePrefab = null;
    [SerializeField] PachinkoGame CurrentGame = null;
    private Vector2 inputVect = Vector2.zero;
    bool paused = false;

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        EndScreen.SetActive(false);
        PauseScreen.SetActive(false);
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        Instantiate(GamePrefab, transform);
        CurrentGame = FindObjectOfType<PachinkoGame>();
    }

    public void EndGame()
    {
        EndScreen.SetActive(true);
        ScoreDisplay.text = CurrentGame.scorePoints.ToString();
        PickupsCollectedDisplay.text = CurrentGame.pickupsCollected.ToString();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!EndScreen.activeSelf)
            {
                paused = !paused;
                PauseScreen.SetActive(paused);
                Time.timeScale = (paused) ? 0 : 1;
            }
        }
    }

    public void Pause()
    {
        if (!EndScreen.activeSelf)
        {
            paused = !paused;
            PauseScreen.SetActive(paused);
            Time.timeScale = (paused) ? 0 : 1;
        }
    }

    public void Trigger(InputAction.CallbackContext context)
    {
        if (context.performed && !paused && CurrentGame)
        {
            CurrentGame.DropBall();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputVect = context.ReadValue<Vector2>();
        inputVect.y = 0;
    }

    private void FixedUpdate()
    {
        if (CurrentGame && !paused)
        {
            CurrentGame.MoveClaw(inputVect);
        }
    }
}
