using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public Image raidTimerIMG;
    public Image peasantTimerIMG;
    public Image warriorTimerIMG;
    public GameObject gameOverPanel;

    public Button peasantButton;
    public Button warriorButton;

    public Text resourcesText;
    public Text peasantCostText;
    public Text warriorCostText;

    public int peasantCount;
    public int warriorCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarriors;

    public int peasantCost;
    public int warriorCost;

    public int peasantCreateTime;
    public int warriorCreateTime;

    public float raidMaxTime;
    public int raidIncrease;
    public int raidIncreaseTime;
    public int nextRaid;

    public AudioManager background;
    public AudioManager ambientSound;
    public AudioManager createSound;
    public AudioManager wrongSound;
    public AudioManager gameMusic;
    public AudioManager newGameClick;
    public AudioManager escapeButton;
    public AudioManager gameOverMusic;
    public AudioManager gameOverPanelSound;

    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer = -2;

    void Start()
    {
        Time.timeScale = 0;
        raidTimer = raidMaxTime;
        raidTimerIMG.fillAmount = 0;


        UpdateText();
        ambientSound.FadeIn();
    }

    void Update()
    {
        if (harvestTimer.tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

        if (eatingTimer.tick)
        {
            wheatCount -= warriorCount * wheatToWarriors;
            if (wheatCount < 0) wheatCount = 0;
        }

        // Peasant timer
        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            peasantTimerIMG.fillAmount = 1 - (peasantTimer / peasantCreateTime);
        }
        else if (peasantTimer > -1)
        {
            peasantTimerIMG.fillAmount = 0;
            peasantCount += 1;
            peasantButton.interactable = true;
            peasantTimer = -2;
        }

        // Warrior timer
        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorTimerIMG.fillAmount = 1 - (warriorTimer / warriorCreateTime);
        }
        else if (warriorTimer > -1)
        {
            warriorTimerIMG.fillAmount = 0;
            warriorCount += 1;
            warriorButton.interactable = true;
            warriorTimer = -2;
        }

        // Raid timer
        if (wheatCount > 20 && raidTimer > 0)
        {
            raidTimer -= Time.deltaTime;
            raidTimerIMG.fillAmount = 1 - (raidTimer / raidMaxTime);
        }
        else if (raidTimer <= 0)
        {
            warriorCount -= nextRaid;
            nextRaid += raidIncrease;
            raidIncrease++;
            raidTimerIMG.fillAmount = 0;
            raidMaxTime += raidIncreaseTime;
            raidTimer = raidMaxTime;
        }

        UpdateText();

        // Game Over
        if (warriorCount < 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            warriorCount = 0;
            gameOverPanelSound.PlayAudio();
            background.FadeOut();
            gameMusic.FadeOut();
            gameOverMusic.FadeIn();
        }
    }

    public void CreatePeasant()
    {
        if (wheatCount >= peasantCost)
        {
            wheatCount -= peasantCost;
            peasantTimer = peasantCreateTime;
            peasantButton.interactable = false;
            createSound.PlayAudio();
        }
        else wrongSound.PlayAudio();
    }

    public void CreateWarrior()
    {
        if (wheatCount >= warriorCost)
        {
            wheatCount -= warriorCost;
            warriorTimer = warriorCreateTime;
            warriorButton.interactable = false;
            createSound.PlayAudio();
        }
        else wrongSound.PlayAudio();
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n" + warriorCount + "\n\n" + wheatCount;
        peasantCostText.text = peasantCost.ToString();
        warriorCostText.text = warriorCost.ToString();
    }

    public void NewGame()
    {
        background.FadeIn();
        newGameClick.PlayAudio();
        gameMusic.FadeIn();
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        escapeButton.PlayAudio();
    }
}
