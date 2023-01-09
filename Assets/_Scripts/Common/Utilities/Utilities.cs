using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev.Utilities
{
    public class Utilities : MonoBehaviour
    {
        public static string CreateRandomName()
        {
            string name = "";

            for (int counter = 1; counter <= 4; ++counter)
            {
                bool upperCase = (Random.Range(0, 2) == 1);

                int rand = 0;
                if (upperCase)
                {
                    rand = Random.Range(65, 91);
                }
                else
                {
                    rand = Random.Range(97, 123);
                }

                name += (char)rand;
            }

            Debug.Log(name);
            return name;
        }
    }
}
