using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{


    private static int _nextLevelIndex = 1;
    private int _numberOfAllLevels;
    [SerializeField]
    string _nextLevelName = "Lvl";


    private void OnEnable()
    {
        _numberOfAllLevels = SceneManager.sceneCountInBuildSettings;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(Enemy._numberOfActiveEnemies <= 0)
        {
            if(_nextLevelIndex < _numberOfAllLevels)
            {

                ++_nextLevelIndex;
                _nextLevelName = "Lvl" + _nextLevelIndex;
                SceneManager.LoadScene(_nextLevelName);

            }
        }
    }


}
