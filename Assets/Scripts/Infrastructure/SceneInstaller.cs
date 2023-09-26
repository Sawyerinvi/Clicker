using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CoinsController>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<ClickerStats>().FromNew().AsSingle();
    }
}
