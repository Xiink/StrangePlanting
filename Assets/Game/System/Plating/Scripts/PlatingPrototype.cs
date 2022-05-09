using System;
using AutoBot.Utilities.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.System.Plating.Scripts
{
    public class PlatingPrototype : MonoBehaviour
    {
        [SerializeField] private Button buttonCreateField;
        [SerializeField] private Button buttonCreatePlant;
        [SerializeField] private Button buttonDeletePlant;
        [SerializeField] private GameObject Field;
        [SerializeField] private GameObject Plant;

        private GameObject filed;
        private GameObject created;

        private void Start()
        {
            buttonCreateField.BindClick(CreateField);
            buttonCreatePlant.BindClick(CreatePlant);
            buttonDeletePlant.BindClick(DeletePlant);
        }

        private void CreateField()
        {
            Vector3 pos = new Vector3(0, -5f, 0);
            filed = Instantiate(Field, pos,Quaternion.identity);
        }

        private void DeletePlant()
        {
            Destroy(created);
        }

        private void CreatePlant()
        {
            var position = filed.transform.position;
            Vector3 pos = new Vector3(position.x, position.y+1.5f, 0);
            created = Instantiate(Plant, pos, Quaternion.identity);
        }
    }
}