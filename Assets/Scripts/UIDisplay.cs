using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Slider healthSlider;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth();
        SetScore();
    }

    private void SetHealth()
    {
        healthSlider.value = playerHealth.GetHealth();
        
    }

    private void SetScore()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000");
    }
}
