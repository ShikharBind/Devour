using UnityEngine;

namespace GameDev.Common
{
    /// <summary>
    /// A static class for general helpful methods
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Destroy all child objects of this transform (Unintentionally evil sounding).
        /// Use it like so:
        /// <code>
        /// transform.DestroyChildren();
        /// </code>
        /// </summary>
        public static void DestroyChildren(this Transform t)
        {
            foreach (Transform child in t) Object.Destroy(child.gameObject);
        }

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
