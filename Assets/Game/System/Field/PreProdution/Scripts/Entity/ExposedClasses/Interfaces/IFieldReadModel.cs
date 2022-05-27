using rStarUtility.DDD.Model;

namespace Game.System.Field.PreProdution.Scripts.Entity.ExposedClasses.Interfaces
{
    public interface IFieldReadModel : IEntity<string>
    {
        #region Public Variables

        string DataId { get; }

        #endregion
    }
}