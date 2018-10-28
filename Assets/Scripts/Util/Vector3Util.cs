using UnityEngine;

namespace Assets.Scripts.Util
{
    class Vector3Util
    {
        static public Vector3 GridVector(Vector3 vec)
        {
            GridVectorInplace(ref vec);
            return vec;
        }

        static public Vector3 GridVectorInplace(ref Vector3 vec)
        {
            vec.x = (int)vec.x;
            vec.z = (int)vec.z;

            if (vec.x % 2 == 0 && vec.z % 2 == 0)
            {
                vec.x = vec.x + 1;
                vec.z = vec.z + 1;
            }

            else if (vec.x % 2 == 1 && vec.z % 2 == 0)
            {
                vec.z = vec.z + 1;
            }

            else if (vec.x % 2 == 0 && vec.z % 2 == 1)
            {
                vec.x = vec.x + 1;
            }

            return vec;
        }
    }
}
