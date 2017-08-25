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

            ValidacionActividadButton.TouchUpInside += (object sender, EventArgs e) =>
             {

                 var Alert = UIAlertController.Create("Aqui deberia validar",
                        "Porque no valida ? el manejador funciona y la nagevacion tambien",
                        UIAlertControllerStyle.Alert);
                 Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                 PresentViewController(Alert, true, null);
             };

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