using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public CharacterSO CharacterSO;
    CharacterSelector CharacterSelector;
    void Awake() 
    {   
        CharacterSO = CharacterSelector.GetCharacterSO();
        SpawnCharacter(CharacterSO.GetCharacterPrefab());
        Debug.Log("VALLAHA DELİRECEM");
    }
    public void SpawnCharacter(GameObject character)
    {   
        Vector3 SpawnPoint = new Vector3 (0f,0f,0f);
        GameObject SpawnedPrefab = Instantiate(character,SpawnPoint,Quaternion.identity);
    }
}
