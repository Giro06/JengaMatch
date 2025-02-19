using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class DebugUIHand : MonoBehaviour
    {
        public bool StartActive;

        public Sprite HandImage;

        public Transform Canvas;

        public Vector2 HandSize = new Vector2(202, 246);
        public Vector2 Offset = new Vector2(50, -50);

        private GameObject _hand;
        private bool _handState;

        private void Awake(){
            _hand = new GameObject("Hand");
            _hand.transform.SetParent(Canvas);

            _hand.AddComponent<RectTransform>();
            _hand.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            _hand.GetComponent<RectTransform>().anchorMax = Vector2.zero;

            Image handImage = _hand.AddComponent<Image>();
            handImage.raycastTarget = false;
            handImage.sprite = HandImage;

            _hand.SetActive(StartActive);
            _handState = StartActive;
        }

        private void Update(){
            _hand.GetComponent<RectTransform>().anchoredPosition = ((Vector2)Input.mousePosition + Offset) / Canvas.transform.localScale.x;

            _hand.GetComponent<RectTransform>().sizeDelta = HandSize;

            if(Input.GetMouseButtonDown(1)){
                _handState = !_handState;
                _hand.SetActive(_handState);
            }
        }
    }
}
