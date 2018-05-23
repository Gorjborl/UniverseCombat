using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour {

    public Text CoinBalance;
    public Canvas LockCanvas;
    public Canvas BuyLevel2Canvas;
    public Canvas InsufficientCoins;
    public Canvas Thanks;
    public Button Yes;
    
    public Button No;
    
    public bool Level2Purchased;
    private int CurrentCoinBalance;
    private string Level2PurchasedString = "Enable";

	// Use this for initialization
	void Start () {

        
        CheckLevel2Purchased();
        CheckLockCanvas();

        CurrentCoinBalance = PlayerPrefs.GetInt("CoinBalance");
        CoinBalance.text = CurrentCoinBalance.ToString();

        
        
        		
	}
	
	// Update is called once per frame
	void Update () {

        CheckLevel2Purchased();
        CheckLockCanvas();
        CoinBalance.text = CurrentCoinBalance.ToString();

    }

    public void ClickYes()
    {
        if ( CurrentCoinBalance >= 200)
        {
            PurchaseLevel2();
            BuyLevel2Canvas.gameObject.SetActive(false);
            Thanks.gameObject.SetActive(true);
        } else
        {
            BuyLevel2Canvas.gameObject.SetActive(false);
            InsufficientCoins.gameObject.SetActive(true);
        }          
            
            

    }

    public void ClickNo()
    {
        BuyLevel2Canvas.gameObject.SetActive(false);
    }

    public void ClickOk()
    {
        InsufficientCoins.gameObject.SetActive(false);
        Thanks.gameObject.SetActive(false);
    }
    void CheckLevel2Purchased()
    {
        if (PlayerPrefs.GetString("IsLevel2Purchased") == Level2PurchasedString)
        {
            Level2Purchased = true;
        }
    }

    void PurchaseLevel2()
    {
        if (CurrentCoinBalance >= 200)
        {
            CurrentCoinBalance -= 200;
            PlayerPrefs.SetInt("CoinBalance",CurrentCoinBalance);
            PlayerPrefs.SetString("IsLevel2Purchased", "Enable");

        } else
        {

            BuyLevel2Canvas.gameObject.SetActive(false);
            InsufficientCoins.gameObject.SetActive(true);

        }
    }

    public void ShowBuyOption()
    {
        BuyLevel2Canvas.gameObject.SetActive(true);
    }

    void CheckLockCanvas()
    {
        if (!Level2Purchased)
        {
            LockCanvas.gameObject.SetActive(true);
        }
        else
        {
            LockCanvas.gameObject.SetActive(false);
        }
    }
}
