using UnityEngine;
/// <summary>
/// List of attributes unique to each vampire instance
/// </summary>
public class VampireAttributes : MonoBehaviour
{
    public bool validWarrant;
    public bool somethingAttempted;
    public float speed = 3f;

    void Start()
    {
        somethingAttempted = false;
    }
}
