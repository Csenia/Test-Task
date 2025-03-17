using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class PlayerProgressInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<XPData>().AsSingle();
        Container.Bind<LevelData>().AsSingle();
        Container.Bind<PlayerProgressPresenter>().AsSingle();

    }
}
