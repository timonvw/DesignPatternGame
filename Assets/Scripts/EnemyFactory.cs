using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private const float baseHealthRanged = 100f;
    private const float baseHealthMelee = 50f;
    private const float baseSpeedRanged = 2.5f;
    private const float baseSpeedMelee = 3f;

    private GameObject rangedPrefab;
    private GameObject meleePrefab;

    private void Awake() {
        rangedPrefab = Resources.Load("Prefabs/Enemies/Ranged") as GameObject;
        meleePrefab = Resources.Load("Prefabs/Enemies/Melee") as GameObject;
    }

    public GameObject CreateEnemy(string enemyType, Vector2 pos) {
        switch (enemyType.ToLower()) {
            case "melee":
                GameObject melee = Instantiate( meleePrefab, pos, Quaternion.identity) as GameObject;
                melee.GetComponent<MeleeEnemy>().Initialise(getRandomName(),
                    baseHealthMelee * GameMaster.Instance.enemyHealthMultiplier,
                    baseSpeedMelee * GameMaster.Instance.enemySpeedMultiplier);
                return melee;
            case "ranged":
                GameObject ranged = Instantiate( rangedPrefab, pos, Quaternion.identity) as GameObject;
                ranged.GetComponent<RangedEnemy>().Initialise(getRandomName(),
                    baseHealthRanged * GameMaster.Instance.enemyHealthMultiplier,
                    baseSpeedRanged * GameMaster.Instance.enemySpeedMultiplier);
                return ranged;
            default:
                return null;
        }
    }

    private string getRandomName() {
        int length = Random.Range(3, 15);
        System.Random random = new System.Random(System.Guid.NewGuid().GetHashCode());
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string name = "";
        name += consonants[random.Next(consonants.Length)].ToUpper();
        name += vowels[random.Next(vowels.Length)];
        int lengthCounter = 2;
        while (lengthCounter < length) {
            name += consonants[random.Next(consonants.Length)];
            lengthCounter++;
            name += vowels[random.Next(vowels.Length)];
            lengthCounter++;
        }
        return name;
     }
}
