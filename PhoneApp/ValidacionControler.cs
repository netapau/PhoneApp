using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneApp
{
    public partial class ValidacionControler : UIViewController
    {
        public ValidacionControler (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //ValidacionButton.TouchUpOutside += async (s, e) =>
            //{
            //    var Client = new SALLab06.ServiceClient();
            //    var Result = await Client.ValidateAsync(CorreoTxt.Text, ContrasenhaTxt.Text, this);

            //    var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token}", UIAlertControllerStyle.Alert);
            //    Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            //    PresentViewController(Alert, true, null);
            //};
        }

        partial void ValidameEstaActividad(UIKit.UIButton sender)
        {
            Valida();
        }

        private async void Valida()
        {
            var Client = new SALLab06.ServiceClient();
            var Result = await Client.ValidateAsync(CorreoTxt.Text, ContrasenhaTxt.Text, this);

            var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token}", UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(Alert, true, null);
        }
    }
}