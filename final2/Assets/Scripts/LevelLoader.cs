using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private CrossFade _crossFade;

    [SerializeField] private EndPoint _endPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerHealth.GetPlayerHealth() <= 0 || _endPoint.IsCompleted())
        {
            _crossFade.FadeIn();
            StartCoroutine("EndLevel");
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level Select");
    }
}
