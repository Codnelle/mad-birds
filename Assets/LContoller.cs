using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LContoller : MonoBehaviour
{
    private monsters[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<monsters>();
    }


    // Update is called once per frame
    void Update()
    {
        foreach(monsters enemy in _enemies)
        { 
            if(enemy != null)
            {
                return;
            }
            Debug.Log("You killed all enemies");
        }
    }
}
