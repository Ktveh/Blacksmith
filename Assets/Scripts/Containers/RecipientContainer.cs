using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipientContainer : Container
{
    private void OnTriggerEnter(Collider other)
    {
        EllapsedTime += Time.deltaTime;

        Container container;
        if (EllapsedTime > Delay && other.TryGetComponent<Container>(out container))
        {
            CheckDonors(container);
            EllapsedTime = 0;
        }
    }
}
