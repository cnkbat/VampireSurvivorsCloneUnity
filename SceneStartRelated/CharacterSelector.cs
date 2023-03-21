using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{

    public static CharacterSelector Instance;
    public CharacterSO CharacterSO;
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public static CharacterSO GetCharacterSO()
    {
        return Instance.CharacterSO;
    }
    public void SelectCharacter(CharacterSO character)
    {
        CharacterSO = character;
    }
    public void DestroySingleton()
    {
        Instance = null;

        Destroy(gameObject);
    }

    
}
