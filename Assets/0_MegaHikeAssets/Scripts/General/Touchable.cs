using UnityEngine;
using UnityEngine.UI;

//this script is for invisible buttons. Normaly unity draws sprites even when they are 0 opacity.
//namespace Game.UI
//{
    public class Touchable : Graphic
    {
        public override bool Raycast(Vector2 sp, Camera eventCamera)
        {
            return true;
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
//}