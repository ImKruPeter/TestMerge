using Zenject;

namespace MergeProj.Field
{
    public class FieldInstaller : Installer<FieldInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FieldView>().FromComponentInNewPrefabResource("FieldView").AsSingle().NonLazy();
        }
    }
}