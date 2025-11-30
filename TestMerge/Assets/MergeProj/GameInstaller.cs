using MergeProj.Camera;
using MergeProj.Field;
using MergeProj.Input;
using MergeProj.MergeObjects;
using Zenject;

namespace MergeProj
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraView>().FromComponentInNewPrefabResource("CameraView").AsSingle().NonLazy();
            
            InputInstaller.Install(Container);
            FieldInstaller.Install(Container);
            MergeInstaller.Install(Container);

            Container.Bind<GameController>().AsSingle().NonLazy();
        }
    }
}