using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace Assets.Scripts.Util
{
    class Vector3Util
    {
        public const float APPROXIMATE_VALUE = 0.00001f;
        static public bool IsAlmostEquals(Vector3 lhs, Vector3 rhs)
        {
            return Mathf.Abs(lhs.x - rhs.x) < APPROXIMATE_VALUE
                   && Mathf.Abs(lhs.y - rhs.y) < APPROXIMATE_VALUE
                   && Mathf.Abs(lhs.z - rhs.z) < APPROXIMATE_VALUE;
        }

        static public bool IsXZAlmostEquals(Vector3 lhs, Vector3 rhs)
        {
            return Mathf.Abs(lhs.x - rhs.x) < APPROXIMATE_VALUE
                   && Mathf.Abs(lhs.z - rhs.z) < APPROXIMATE_VALUE;
        }

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
