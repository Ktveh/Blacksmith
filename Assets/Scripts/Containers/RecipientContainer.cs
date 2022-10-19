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
            foreach (Container donor in Donors)
            {
                if (container.gameObject == donor.gameObject)
                {
                    Take(container);
                }
            }
            EllapsedTime = 0;
        }
    }
}
