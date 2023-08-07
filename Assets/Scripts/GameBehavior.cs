using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public void UpdateScene(string updateText)
    {
        progressText.text = updateText;
        Time.timeScale = 0;
    }

    public int maxItems = 4;

    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;

    public Button winButton;
    public Button lostButton;
    private int _itemsCollected = 0;
    private int _playerHp = 1;


    public int items
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;

            itemText.text = "Items Collected: " + items;

            if (_itemsCollected >= maxItems)
            {
                winButton.gameObject.SetActive(true);

                UpdateScene("You've found all the items!");
            }
            else
            {
                progressText.text = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int HP
    {
        get
        {
            return _playerHp;
        }
        set
        {
            _playerHp = value;

            healthText.text = "Player Health: " + HP;

            if (_playerHp <= 0)
            {
                lostButton.gameObject.SetActive(true);

                UpdateScene("You want another life with that?");
            }
            else
            {
                progressText.text = "Ouch... that's go hurt.";
            }
        }
    }

    private void Start()
    {
        itemText.text += _itemsCollected;

        healthText.text += _playerHp;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);

        //Reiniciar la scena con los valores por defecto
        Time.timeScale = 1f;
    }
}
