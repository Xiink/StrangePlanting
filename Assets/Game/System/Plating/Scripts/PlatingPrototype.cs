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
        [SerializeField] private GameObject Plant;

        private GameObject created;

        private void Start()
        {
            buttonCreatePlant.BindClick(CreatePlant);
            buttonDeletePlant.BindClick(DeletePlant);
        }

        private void DeletePlant()
        {
            Destroy(created);
        }

        private void CreatePlant()
        {
            created = Instantiate(Plant, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}