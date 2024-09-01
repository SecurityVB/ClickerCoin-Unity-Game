using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuMain : MonoBehaviour
{
    [SerializeField] int money;
    
    public int clicks;
    public int factor = 1;

    public TextMeshProUGUI moneyText;
    public GameObject Button;
    public Sprite[] Skins;


    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        clicks = PlayerPrefs.GetInt("clicks");
        factor = PlayerPrefs.GetInt("factor");
        ButtonChange();
    }

    // Start is called before the first frame update
    public void ButtonClick()
    {
        money += factor;
        clicks++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("clicks", clicks);
    }


    public void ToRewards()
    {
        SceneManager.LoadScene(1);
    }

    public void ToShop()
    {
        SceneManager.LoadScene(2);
    }

    public void ToInfo()
    {
        SceneManager.LoadScene(3);
    }

    public void ButtonChange()
    {
        int Skin = 0;
        if (PlayerPrefs.HasKey("Skin"))
        {
            Skin = PlayerPrefs.GetInt("Skin");
            Button.GetComponent<Image>().sprite = Skins[Skin];
        }
        else
        {
            Button.GetComponent<Image>().sprite = Skins[Skin];
        }
    }

    void Update()
    {
        moneyText.text = money.ToString() + "$";
    }
}
