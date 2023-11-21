using System;
using UnityEngine;

namespace _Scripts
{
    public class ParallaxEffect : MonoBehaviour
    {
        private float _startingPos;
        public float _lengthOfSprite;
        public float AmountOfParallax; 
        public Camera MainCamera;



        private void Start()
        {
            _startingPos = transform.position.x; 
        }



        private void Update()
        {
            Vector3 Position = MainCamera.transform.position;
            float Temp = Position.x * (1 - AmountOfParallax);
            float Distance = Position.x * AmountOfParallax;

            Vector3 NewPosition = new Vector3(_startingPos + Distance, transform.position.y, transform.position.z);

            transform.position = NewPosition;

            if (Temp > _startingPos + (_lengthOfSprite / 2))
            {
                _startingPos += _lengthOfSprite;
            }
            else if (Temp < _startingPos - (_lengthOfSprite / 2))
            {
                _startingPos -= _lengthOfSprite;
            }
        }
    }
}