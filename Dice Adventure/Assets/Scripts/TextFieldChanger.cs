using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TextFieldChanger : MonoBehaviour
{
    //text field
    public TextMeshProUGUI textField;

    //buttons for spell selection
    public GameObject torrent;
    public GameObject fireball;
    public GameObject shockwave;
    public GameObject boulderush;
    public GameObject smite;

    //default button selection for when the player clicks off buttons
    public Button defaultSelect;

    //buttons for enemy selection
    public GameObject funnySkeleton;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        // Compare selected gameObject with referenced Button gameObject
        if (EventSystem.current.currentSelectedGameObject == torrent)
        {
            textField.text = "Spell: Torrent - Deals 1 Damage to Target Enemy\n" +
                "Cost: 1 mana";
        } else if (EventSystem.current.currentSelectedGameObject == fireball)
        {
            textField.text = "Spell: Fireball - Deals 3 Damage to Target Enemy\n" +
                "Cost: 2 mana";
        } else if (EventSystem.current.currentSelectedGameObject == shockwave)
        {
            textField.text = "Spell: Shockwave - Deals 1 Damage to all enemies\n" +
                "Cost: 2 mana";
        } else if (EventSystem.current.currentSelectedGameObject == boulderush)
        {
            textField.text = "Spell: Boulderush - Deals 3 Damage to all enemies\n" +
                "Cost: 4 mana";
        } else if (EventSystem.current.currentSelectedGameObject == smite)
        {
            textField.text = "Spell: Smite - Deals 2 damage to selected enemy. If enemy is defeated, heal 5 health\n" +
                "Cost: 3 mana";
        } else if (EventSystem.current.currentSelectedGameObject == null)
        {
            defaultSelect.Select();
        }
    }
}
