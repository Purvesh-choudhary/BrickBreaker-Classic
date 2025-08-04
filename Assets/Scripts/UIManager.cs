using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    [SerializeField] TextMeshProUGUI livesUI, scoreUI;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateScoreUI(int score){
        scoreUI.text = score.ToString();
    } 

    public void UpdateLivesUI(int lives){
        livesUI.text = lives.ToString();
    }

}
