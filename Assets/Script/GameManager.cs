using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Monster lastMonster;
    public GameObject monsterPrefab;
    public float nextLevel;
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        nextLevel = 1f;
        NextMonster();
    }

    private Monster GetMonster()
    {

        GameObject monsterInstant = Instantiate(monsterPrefab);
        Monster newMonster = monsterInstant.GetComponent<Monster>();

        return newMonster;
    }

    private void NextMonster()
    {
        Monster newMonster = GetMonster();
        lastMonster = newMonster;
        lastMonster.HealthPoint = lastMonster.HealthPoint * nextLevel;

        lastMonster.transform.localScale = new Vector3(lastMonster.transform.localScale.x + nextLevel, lastMonster.transform.localScale.y + nextLevel, 1);
        nextLevel += 0.5f;
        StartCoroutine(WaitNextLevel());
    }

    IEnumerator WaitNextLevel()
    {
        while (lastMonster != null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        NextMonster();
    }

}
