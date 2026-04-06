using UnityEngine;
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

    void Start()
    {
        somethingAttempted = false;
    }

    public void validateReport()
    {
        if (reported)
        {
            if (violation)
            {
                Debug.Log("Vampire has been reported CORRECTLY!");
            }
            else
            {
                Debug.Log("Vampire has been reported INCORRECTLY!");
            }
        }
    }
}
