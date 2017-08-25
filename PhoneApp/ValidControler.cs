using Foundation;
using System;
using UIKit;

namespace PhoneApp
{
    public partial class ValidControler : UIViewController
    {
        public ValidControler (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        partial void ValidacionActividadButton_TouchUpInside(UIButton sender)
        {
            Validate();
        }

        private async void Validate()
        {
            var Client = new SALLab06.ServiceClient();
            var Result = await Client.ValidateAsync(CorreoTxt.Text, ContrasenhaTxt.Text, this);

            var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token}", UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(Alert, true, null);
        }
    }
}