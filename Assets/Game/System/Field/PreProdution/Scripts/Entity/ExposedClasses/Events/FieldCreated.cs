namespace Game.System.Field.PreProdution.Scripts.Entity.ExposedClasses.Events
{
    public class FieldCreated
    {
        public string FieldId;
        public string FieldDataId;

        public FieldCreated(string fieldId, string fieldDataId)
        {
            this.FieldId = fieldId;
            this.FieldDataId = fieldDataId;
        }
    }
}