using UnityEngine;
using Zenject;

namespace Game.System.Field.PreProdution.Scripts.Application.Installer
{
    public class FieldPreProductionInstall : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Data0>().AsSingle();
        }
    }

    public class Data0
    {
        public void LogData(string dataid)
        {
            Debug.Log(dataid);
        }
    }
}