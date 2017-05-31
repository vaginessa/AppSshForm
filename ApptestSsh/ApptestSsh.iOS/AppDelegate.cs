﻿using System;
using System.Collections.Generic;
using System.Linq;
using ApptestSsh.Core;
using Autofac;
using Doods.StdFramework.ApplicationObjects;
using Doods.StdRepository.Interfaces;
using Foundation;
using UIKit;

namespace ApptestSsh.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            CoreSetup.SetupContainer(new Setup());
            AppContainer.Container.Resolve<IDatabase>().Initialize();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}