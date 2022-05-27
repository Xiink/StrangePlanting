//using Game.System.Field.PreProdution.Scripts.UseCase;

using Game.System.Field.PreProdution.Scripts.Entity.ExposedClasses.Interfaces;
using Game.System.Field.PreProdution.Scripts.UseCase;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.DDD.DDDTestFrameWork;
using Zenject;

namespace Game.System.Field.PreProdution.Scripts.FieldTests
{
    [TestFixture]
    public class FieldCreatedUseCaseTest : DDDUnitTestFixture
    {
        [Test]
        public void Should_Success_When_Crated_Field()
        {
            Container.Bind<IFieldRespository>().FromSubstitute();
            Container.Bind<FieldCreatedUseCase>().AsSingle();

            var createActorUseCase = Container.Resolve<FieldCreatedUseCase>();
            var repository = Container.Resolve<IFieldRespository>();

            // Entity.Field field = null;
            // repository.Save(Arg.Do<Entity.Field>(f=>field = f));
        }
    }
}