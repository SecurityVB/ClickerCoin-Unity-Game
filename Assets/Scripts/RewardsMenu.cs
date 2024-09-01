using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class RewardsMenu : MonoBehaviour
{
    public int money;
    public int clicks;
    public int factor = 1;
    public int[] factors;

    public GameObject[] rewards;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        clicks = PlayerPrefs.GetInt("clicks");
        factor = PlayerPrefs.GetInt("factor");
        CheckRewards();
    }

    public void Reward1()
    {
        if (clicks >= 490)
        {
            PlayerPrefs.SetInt("factor", factors[0]);
            CheckRewards();
        }
        
    }

    public void Reward2()
    {
        if (clicks >= 1000)
        {
            PlayerPrefs.SetInt("factor", factors[1]);
            CheckRewards();
        }
    }

    public void Reward3()
    {
        if (clicks >= 4999)
        {
            PlayerPrefs.SetInt("factor", factors[2]);
            CheckRewards();
        }
    }

    public void Reward4()
    {
        if (clicks >= 10000)
        {
            PlayerPrefs.SetInt("factor", factors[3]);
            CheckRewards();
        }
    }

    public void Reward5()
    {
        if (clicks >= 19999)
        {
            PlayerPrefs.SetInt("factor", factors[4]);
            CheckRewards();
        }
    }

    public void Reward6()
    {
        if (clicks >= 29999)
        {
            PlayerPrefs.SetInt("factor", factors[5]);
            CheckRewards();
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }



    public void CheckRewards()
    {
        int index = 0;
        for (int i=0; i < factors.Length; i++)
        {
            if (factor == factors[i])
            {
                index = i;
            }
        }

        for (int n = index; n >= 0; n--)
        {
            rewards[n].GetComponent<Button>().interactable = false;
            rewards[n].GetComponentsInChildren<Image>()[1].color = new Color(200f, 200f, 200f, 0.5f);
        }
    }
}
