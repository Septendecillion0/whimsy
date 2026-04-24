using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// List of attributes unique to each vampire instance
/// </summary>
public class VampireAttributes : MonoBehaviour
{
    public bool validWarrant;
    public bool reported = false;
    public bool combusted = false;
    public bool somethingAttempted;
    public float speed = 3f;
    public bool violation = false;

    [SerializeField] public List<Sprite> spriteList;
    //[SerializeField] public List<Sprite> hatSpriteList;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //SpriteRenderer hatSpriteRenderer = GameObject.Find("Hat").GetComponent<SpriteRenderer>();

        int randomIndex = Random.Range(0, spriteList.Count);

        spriteRenderer.sprite = spriteList[randomIndex];

        //hatSpriteRenderer.sprite = hatSpriteList[randomIndex];
        // if (randomIndex == 1)
        // {
        //     gameObject.transform.Find("Hat").position = new Vector2(-1.51f, 3.27f);
        // }

        somethingAttempted = false;
    }

    public void validateReport()
    {
        if (reported)
        {
            if (violation)
            {
                //Debug.Log("Vampire has been reported CORRECTLY!");
                UIManager.Instance.SendMessage("A vampire has been reported correctly!", Color.green);

            }
            else
            {
                //Debug.Log("Vampire has been reported INCORRECTLY!");
                UIManager.Instance.SendMessage("A vampire has been reported incorrectly!", Color.red);
            }
        }
    }
}
