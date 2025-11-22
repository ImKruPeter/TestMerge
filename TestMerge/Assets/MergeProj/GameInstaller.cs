using MergeProj.Camera;
using Zenject;

namespace MergeProj
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraView>().FromNewComponentOnNewPrefabResource("CameraView").AsSingle().NonLazy();
        }
    }
}