using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinController : MonoBehaviour
{
   
    void Start()
    {
        if (GameController.isGameWin == false) Destroy(gameObject);
    }
    
}
