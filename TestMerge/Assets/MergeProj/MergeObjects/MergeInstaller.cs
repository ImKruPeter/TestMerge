using Zenject;

namespace MergeProj.MergeObjects
{
    public class MergeInstaller : Installer<MergeInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MergeObjectModels>().FromScriptableObjectResource("MergeObjectModels").AsSingle().NonLazy();
            Container.Bind<MergeObjectFactory>().AsSingle().NonLazy();
            Container.Bind<MergeController>().AsSingle().NonLazy();
        }
    }
}