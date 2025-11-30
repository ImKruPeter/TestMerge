using Zenject;

namespace MergeProj.Input
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
            Container.Bind<InputController>().AsSingle().NonLazy();
            Container.Bind<InputManager>().AsSingle().NonLazy();
        }
    }
}