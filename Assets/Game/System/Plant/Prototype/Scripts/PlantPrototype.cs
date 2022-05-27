using rStarUtility.Util.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.System.Plant.Prototype.Scripts
{
    internal enum PlantStat
    {
        Seed,Fertilize,Plant
    }

    public class PlantPrototype : MonoBehaviour
    {
        #region Private Variables

        private PlantStat _state;
        [SerializeField] private GameObject _field;
        [SerializeField] private GameObject _seed;
        [SerializeField] private SpriteRenderer _seedSprite;
        [SerializeField] private Sprite _plant;
        [SerializeField] private Button _buttonAddFertilize;
        [SerializeField] private Button _buttonGrowup;
        [SerializeField] private TMP_Text _statText;

        #endregion

        #region Unity events

        private void Start()
        {
            _buttonAddFertilize.BindClick(AddFertilize);
            _buttonGrowup.BindClick(Growup);
            ChangeState(PlantStat.Seed);
        }

        #endregion

        #region Private Methods
        private void ChangeState(PlantStat newState)
        {
            _state = newState;
            HandleStateChange();
        }

        private void HandleStateChange()
        {
            Debug.Log($"CurrentState: {_state}");
            _statText.text = _state.ToString();
        }

        private void AddFertilize()
        {
            ChangeState(PlantStat.Fertilize);
        }

        private void Growup()
        {
            if(_state != PlantStat.Fertilize) return;

            _seedSprite.sprite = _plant;
            ChangeState(PlantStat.Plant);
        }

        #endregion
    }
}