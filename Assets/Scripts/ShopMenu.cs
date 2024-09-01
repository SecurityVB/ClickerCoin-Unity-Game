using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class ShopMenu : MonoBehaviour
{ 
	public int			money;
	public int			total_money;
    public int			i = 0;
    public int          index = 0;

    private bool[]		EquipCheck;
    private bool[]		BuyCheck;

    public Product[]	Shop;

    public GameObject[] products;
    public Image[]		images;

	public Sprite locked;
	public Sprite unlocked;
    public Sprite equipped;




    void Start()
	{
		money = PlayerPrefs.GetInt("money");
		total_money = PlayerPrefs.GetInt("total_money");

        EquipCheck = new bool[5];
		BuyCheck = new bool[5];

		if (PlayerPrefs.HasKey("EquipArray"))
		{
			EquipCheck = PlayerPrefsX.GetBoolArray("EquipArray");
		}
		else
		{
			EquipCheck[0] = true;
		}

        if (PlayerPrefs.HasKey("BuyArray"))
        {
            BuyCheck = PlayerPrefsX.GetBoolArray("BuyArray");
        }
		BuyCheck[0] = true;


        foreach (var product in products)
		{
			Shop[i].product = product;
            images = product.GetComponentsInChildren<Image>();
            Shop[i].icon = images[2];
            ++i;
        }
		ChangeIcon();
        Save();
    }


	public void Product_1()
	{
		if (!EquipCheck[0])
		{
            EquipCheck[0] = true;
            EquipCheck[1] = false;
            EquipCheck[2] = false;
            EquipCheck[3] = false;
            EquipCheck[4] = false;
        }
		ChangeIcon();
        Save();
    }


	public void Product_2()
	{
		if (!BuyCheck[1])
		{
			if (money >= 1500)
			{
				PlayerPrefs.SetInt("money", money - 1500);
				BuyCheck[1] = true;
            }
		}
		else if (BuyCheck[1])
		{
			if (!EquipCheck[1])
			{
                EquipCheck[0] = false;
                EquipCheck[1] = true;
                EquipCheck[2] = false;
                EquipCheck[3] = false;
                EquipCheck[4] = false;
            }
		}
        ChangeIcon();
        Save();
	}


    public void Product_3()
    {
        if (!BuyCheck[2])
        {
            if (money >= 5500)
            {
                PlayerPrefs.SetInt("money", money - 5500);
                BuyCheck[2] = true;
            }
        }
        else if (BuyCheck[2])
        {
            if (!EquipCheck[2])
            {
                EquipCheck[0] = false;
                EquipCheck[1] = false;
                EquipCheck[2] = true;
                EquipCheck[3] = false;
                EquipCheck[4] = false;
            }
        }
        ChangeIcon();
        Save();
    }


    public void Product_4()
    {
        if (!BuyCheck[3])
        {
            if (money >= 10000)
            {
                PlayerPrefs.SetInt("money", money - 10000);
                BuyCheck[3] = true;
            }
        }
        else if (BuyCheck[3])
        {
            if (!EquipCheck[3])
            {
                EquipCheck[0] = false;
                EquipCheck[1] = false;
                EquipCheck[2] = false;
                EquipCheck[3] = true;
                EquipCheck[4] = false;
            }
        }
        ChangeIcon();
        Save();
    }


    public void Product_5()
    {
        if (!BuyCheck[4])
        {
            if (money >= 29000)
            {
                PlayerPrefs.SetInt("money", money - 29000);
                BuyCheck[4] = true;
            }
        }
        else if (BuyCheck[4])
        {
            if (!EquipCheck[4])
            {
                EquipCheck[0] = false;
                EquipCheck[1] = false;
                EquipCheck[2] = false;
                EquipCheck[3] = false;
                EquipCheck[4] = true;
            }
        }
        ChangeIcon();
        Save();
    }




    public void ChangeIcon()
	{
		for (int c=0; c < 5; c++)
		{
			if (BuyCheck[c] == true)
			{
				Shop[c].icon.sprite = unlocked;
			}
            else if (BuyCheck[c] == false)
			{
                Shop[c].icon.sprite = locked;
            }

            if (EquipCheck[c] == true)
            {
                Shop[index].product.GetComponent<Button>().interactable = true;
                Shop[index].icon.color = new Color(255f, 255f, 255f, 1f);
                Shop[index].product.GetComponentsInChildren<Image>()[1].color = new Color(255f, 255f, 255f, 1f);

                PlayerPrefs.SetInt("Skin", c);
                Shop[c].icon.sprite = equipped;
                Shop[c].product.GetComponent<Button>().interactable = false;
                Shop[c].icon.color = new Color(200f, 200f, 200f, 0.5f);
                Shop[c].product.GetComponentsInChildren<Image>()[1].color = new Color(200f, 200f, 200f, 0.5f);

                index = c;
            }
        }
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("BuyArray", BuyCheck);
        PlayerPrefsX.SetBoolArray("EquipArray", EquipCheck);
    }

    public void ToMenu()
	{
		SceneManager.LoadScene(0);
	}
}




[System.Serializable]
public class Product
{
    public GameObject product; // Кнопка
    public Image icon;         // Image
    //public int price;          // Цена товара
}