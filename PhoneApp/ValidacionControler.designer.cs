﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PhoneApp
{
    [Register ("ValidacionControler")]
    partial class ValidacionControler
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ContrasenhaTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CorreoTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ValidacionButton { get; set; }

        [Action ("ValidacionButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ValidacionButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ContrasenhaTxt != null) {
                ContrasenhaTxt.Dispose ();
                ContrasenhaTxt = null;
            }

            if (CorreoTxt != null) {
                CorreoTxt.Dispose ();
                CorreoTxt = null;
            }

            if (ValidacionButton != null) {
                ValidacionButton.Dispose ();
                ValidacionButton = null;
            }
        }
    }
}