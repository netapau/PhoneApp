// WARNING
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
    [Register ("ValidarViewControler")]
    partial class ValidarViewControler
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ValidarTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ValidarTableView != null) {
                ValidarTableView.Dispose ();
                ValidarTableView = null;
            }
        }
    }
}