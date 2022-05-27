using System.Runtime.InteropServices.WindowsRuntime;
using rStarUtility.DDD.Event;
using rStarUtility.DDD.Implement.Core;
using rStarUtility.DDD.Implement.CQRS;
using rStarUtility.DDD.Usecase;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Field.PreProdution.Scripts.UseCase
{
    public class FieldCreatedUseCase : UseCase<FieldCreatedUseCase.FieldCratedInput, CqrsCommandPresenter, IFieldRespository>
    {
        public FieldCreatedUseCase(IDomainEventBus domainEventBus, IFieldRespository repository) : base(domainEventBus,
            repository)
        {
        }

        public override void Execute(FieldCratedInput input, CqrsCommandPresenter output)
        {
            throw new NotImplementedException();
        }

        public class FieldCratedInput : Input
        {
            public string filedId;
            public string fieldDataId;
        }
    }
}