using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject generator;
    float time = 30.0f;
    int point = 0;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
    }


    void Update()
    {
        this.time -= Time.deltaTime;

        if(this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetPrameter(10000.0f, 0, 0);
        }
        else if(0 <= this.time && this.time < 4)
        {
            this.generator.GetComponent<ItemGenerator>().SetPrameter(0.3f, -0.06f, 3);
        }
        else if(4 <= this.time && this.time < 12)
        {
            this.generator.GetComponent<ItemGenerator>().SetPrameter(0.5f, -0.05f, 6);
        }
        else if(12 <= this.time && this.time < 23)
        {
            this.generator.GetComponent<ItemGenerator>().SetPrameter(0.8f, -0.04f, 4);
        }
        else if(23 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetPrameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";
    }
}