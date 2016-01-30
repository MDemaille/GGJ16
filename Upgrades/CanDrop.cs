using UnityEngine;
using System.Collections;

public class CanDrop : MonoBehaviour {
    public DropableItem[] possibleDrops;

    DropableItem drop()
    {
        int max = 0;
        for (int i = 0; i < possibleDrops.Length; ++i)
            max += possibleDrops[i].dropRate;

        int nb = Random.Range(0, max-1);

        int sum = 0;
        for (int i = 0; i < possibleDrops.Length; ++i)
        {
            sum += possibleDrops[i].dropRate;
            if (nb < sum)
                return possibleDrops[i];
        }

        Debug.Log("Le drop s'est pas bien passé.");
        return possibleDrops[0];
    }
}
