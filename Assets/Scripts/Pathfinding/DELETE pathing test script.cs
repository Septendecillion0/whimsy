using System.Collections;
using UnityEngine;

public class DELETEpathingtestscript : MonoBehaviour
{
    public VampirePathing pathing;
    public VampireAttributes attributes;

    public Checkpoint nextDestination;

    void Start()
    {
        if (pathing != null)
        {
            pathing.OnDestinationReached += HandleDestinationReached;
        }
    }

    void HandleDestinationReached(VampirePathing vampire)
    {
        Debug.Log("Test script triggered!");

        // Modify attribute
        attributes.somethingAttempted = true;
        Debug.Log("attempted to do something");

        // Start delayed action
        StartCoroutine(WaitAndRedirect());
    }

    IEnumerator WaitAndRedirect()
    {
        yield return new WaitForSeconds(5f);

        Debug.Log("Redirecting to new destination...");

        pathing.SetNewDestination(nextDestination);
    }
}