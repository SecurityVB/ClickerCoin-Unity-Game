using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoMenu : MonoBehaviour
{
    [SerializeField] int money;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI factorText;
    public int clicks;
    public int factor = 1;


    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        clicks = PlayerPrefs.GetInt("clicks");
        factor = PlayerPrefs.GetInt("factor");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        moneyText.text = money.ToString() + "$";
        clicksText.text = clicks.ToString();
        factorText.text = factor.ToString();
    }
}
