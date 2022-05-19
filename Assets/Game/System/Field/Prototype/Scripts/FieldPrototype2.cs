using AutoBot.Utilities.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Plating.Scripts
{
    internal enum FieldState
    {
        Empty,
        Fill,
        Fertilize,
        GrowUp
    }

    public class FieldPrototype2 : MonoBehaviour
    {
        #region Private Variables

        private GameObject _newPlant;

        private GameObject _newSeed;
        private FieldState _state;

        private int harvestedPlantCount = 0;
        [SerializeField] private Button buttonCreatePlant;
        [SerializeField] private Button buttonDeletePlant;
        [SerializeField] private Button buttonFertilize;
        [SerializeField] private Button buttonGrowingUp;
        [SerializeField] private Button buttonHarvest;
        [SerializeField] private TMP_Text _textState;
        [SerializeField] private TMP_Text _textCount;
        [SerializeField] private GameObject Seed;
        [SerializeField] private GameObject Plant;

        #endregion

        #region Unity events

        private void Start()
        {
            buttonCreatePlant.BindClick(CreateSeed);
            buttonDeletePlant.BindClick(DeleteSeed);
            buttonFertilize.BindClick(FertilizeField);
            buttonGrowingUp.BindClick(GrowingUp);
            buttonHarvest.BindClick(Harvest);
            ChangeState(FieldState.Empty);
        }

        #endregion

        #region Private Methods

        private void ChangeState(FieldState newState)
        {
            _state = newState;
            HandleStateChange();
        }

        private void CreateSeed()
        {
            if (_state == FieldState.Fill) return;

            var position = this.transform.position;
            Vector3 pos = new Vector3(position.x, position.y + 1f, -1);
            _newSeed = Instantiate(Seed, pos, Quaternion.identity);
            _newSeed.transform.parent = this.transform;
            ChangeState(FieldState.Fill);
        }

        private void DeletePlant()
        {
            Destroy(_newPlant);
            ChangeState(FieldState.Empty);
        }

        private void DeleteSeed()
        {
            if (_state == FieldState.GrowUp) return;

            Destroy(_newSeed);
            ChangeState(FieldState.Empty);
        }

        private void FertilizeField()
        {
            if (_state == FieldState.Empty) return;

            ChangeState(FieldState.Fertilize);
        }

        private void GrowingUp()
        {
            if (_state != FieldState.Fertilize) return;


            DeleteSeed();
            var position = this.transform.position;
            Vector3 pos = new Vector3(position.x, position.y + 1f, -1);
            _newPlant = Instantiate(Plant, pos, Quaternion.identity);
            _newPlant.transform.parent = this.transform;
            ChangeState(FieldState.GrowUp);
        }

        private void HandleStateChange()
        {
            Debug.Log($"CurrentState: {_state}");
            _textState.text = _state.ToString();
        }

        private void Harvest()
        {
            if (_state != FieldState.GrowUp) return;
            harvestedPlantCount++;
            _textCount.text = $"Count:{harvestedPlantCount}";
            DeletePlant();
        }

        #endregion
    }
}