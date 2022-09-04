using System.Collections.Generic;
using UnityEngine;

namespace OPSystems.Random
{

    public class SeedRandom : ScriptableObject
    {
        public int Seed { get; private set; }

        public void SetString(string newSeed = "")
        {
            if (_isNumeric(newSeed))
            {
                Seed = int.Parse(newSeed);
            }
            else
            {
                Seed = newSeed.GetHashCode();
            }

            if (Seed == 0)
            {
                Seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            }

        }

        private bool _isNumeric(string stringToCheck) => int.TryParse(stringToCheck, out int tempInt);

    }

}