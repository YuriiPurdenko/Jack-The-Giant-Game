using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptiomManager : MonoBehaviour
{

    [SerializeField] GameObject easySign, mediumSign,hardSign;

    void Start() {
        SetTheDifficulty();    
    }
    void SetInitialDifficulty(string difficulty){
        switch(difficulty){
            case "easy":
                easySign.SetActive(true);
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "medium":
            
                easySign.SetActive(false);
                mediumSign.SetActive(true);
                hardSign.SetActive(false);
                break;
            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                hardSign.SetActive(true);
                break;
        }

    }

    void SetTheDifficulty(){
        if(GamePreferences.GetEasyDifficultyState()){
            SetInitialDifficulty("easy");
        }
        else if(GamePreferences.GetMediumDifficultyState()){
            SetInitialDifficulty("medium");
        }
        else if(GamePreferences.GetHardDifficultyState()){
            SetInitialDifficulty("hard");
        }
    }


    public void EasyDifficulty(){
        GamePreferences.SetEasyDifficultyState(true);
        GamePreferences.SetMediumDifficultyState(false);
        GamePreferences.SetHardDifficultyState(false);
        SetTheDifficulty();

    }
    public void MediumDifficulty(){
        GamePreferences.SetEasyDifficultyState(false);
        GamePreferences.SetMediumDifficultyState(true);
        GamePreferences.SetHardDifficultyState(false);
        SetTheDifficulty();
    }
    public void HardDifficulty(){
        GamePreferences.SetEasyDifficultyState(false);
        GamePreferences.SetMediumDifficultyState(false);
        GamePreferences.SetHardDifficultyState(true);
        SetTheDifficulty();
    }





    // Start is called before the first frame update
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
