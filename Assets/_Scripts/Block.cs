using UnityEngine;

namespace _Scripts
{
    public class Block : MonoBehaviour
    {
        public BlockColor blockColor;

        public void SetMaterial(Material material)
        {
            GetComponent<MeshRenderer>().material = material;
        }
    }

    public enum BlockColor
    {
        Color1,
        Color2,
        Color3,
        Color4,
        Color5
    }
}