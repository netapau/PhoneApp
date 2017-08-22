using System;
using System.Collections.Generic;
using Foundation;
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

            ValidacionActividadButton.TouchUpOutside += ValidacionActividadButton_TouchUpOutside;
        }

        private void ValidacionActividadButton_TouchUpOutside(object sender, EventArgs e)
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