using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public int maxItems = 4;

    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;

    public Button winButton;

    private int _itemsCollected = 0;
    private int _playerHp = 10;



    private void Start()
    {
        itemText.text += _itemsCollected;
        healthText.text += _playerHp;
    }

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

            if(_itemsCollected >= maxItems)
            {
                progressText.text = "You've found all the items!";
                winButton.gameObject.SetActive(true);

                //Pusar el juego
                Time.timeScale = 0f;
            }
            else
            {
                progressText.text = "Item found, only " + (maxItems - _itemsCollected) + "more to go!";
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
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);

        //Reiniciar la scena con los valores por defecto
        Time.timeScale = 1f;
    }
}
