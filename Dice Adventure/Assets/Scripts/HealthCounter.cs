using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    bool healthChanged = false;
    int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        healthChanged = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if health changes (using boolean variable to determine) then change the text number.
        if (healthChanged)  
        {
            //set text to value health .GetComponent<TextMeshPro>().
            healthText.text = health.ToString();
            //set bool to false again so we can only change it when the value changes.
            healthChanged = false;
        }
    }
}
