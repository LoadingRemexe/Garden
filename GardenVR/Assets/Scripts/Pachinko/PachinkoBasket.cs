using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PachinkoBasket : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label = null;
    [SerializeField] GameObject particlesPrefab = null;

    PachinkoGame gameOwner = null;
    private int ScoreMin = 1;
    private int ScoreMax = 5;
    private int Score = 100;

    private void Start()
    {
        gameOwner = FindObjectOfType<PachinkoGame>();
        ResetBasket();
    }

    public void ResetBasket()
    {
        Score = Random.Range(ScoreMin, ScoreMax + 1) * 100;
        label.text = Score.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        AudioManager.Instance.PlaySuccess();
        Instantiate(particlesPrefab, transform.position, Quaternion.identity, null);
        gameOwner.AddScore(Score);
    }


}
