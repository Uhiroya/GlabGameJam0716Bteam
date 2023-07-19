using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        SaveManager.Money = 0;
        SaveManager.ShootResult = 0;
        SaveManager.GoldFishingResult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
