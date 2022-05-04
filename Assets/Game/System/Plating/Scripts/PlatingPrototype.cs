using System;
using AutoBot.Utilities.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.System.Plating.Scripts
{
    public class PlatingPrototype : MonoBehaviour
    {
        [SerializeField] private Button buttonCreatePlant;
        [SerializeField] private Button buttonDeletePlant;
        [SerializeField] private Sprite Plant;

        private void Start()
        {
            buttonCreatePlant.BindClick(CreatePlant);
            buttonDeletePlant.BindClick(DeletePlant);
        }

        private void DeletePlant()
        {
            
        }

        private void CreatePlant()
        {
            
        }
    }
}