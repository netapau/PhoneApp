using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneApp
{
    public partial class ViewController : UIViewController
    {
        // Numero a llamar
        string TranslatedNumber = string.Empty;

        List<string> PhoneNumbers = new List<string>();

        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            TranslateButton.TouchUpInside += (object sender, EventArgs e) => 
            {
                var Translator = new PhoneTranslator();

                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    //No hay numero a llamar
                    CallButton.SetTitle("Llamar", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    // Hay un posible numero telefonico a llamar
                    CallButton.SetTitle($"Llamar al {TranslatedNumber}", UIControlState.Normal);
                    CallButton.Enabled = true;
                }

            };

            // Llama.
            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                PhoneNumbers.Add(TranslatedNumber);

                var URL = new Foundation.NSUrl($"tel:{TranslatedNumber}");
                //Utilizar el manejador de url con el prefijo tel: para invocar a la 
                //aplicacion Phone de apple, de lo contrario mostrar un dialogo de alerta.
                if (!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var Alert = UIAlertController.Create("No soportado", 
                        "El esquema 'tel:' no es soportado en este dispositivo", 
                        UIAlertControllerStyle.Alert);
                    Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(Alert, true, null);
                }
            };

            // Maneja navegacion mediante codigo (hay que poner el ID en las propriedades !)
            CallHistoryButton.TouchUpInside += (sender, arg) =>
            {
                // Puede instanciarse el controlador con ID "CallHistoryControler" ?
                // establecido en el diseñador.
                if (this.Storyboard.InstantiateViewController("CallHistoryControler") is CallHistoryControler Controler)
                {
                    // Proporciona la lista de numeros telefonicos al CallHistoryControler
                    Controler.PhoneNumbers = PhoneNumbers;
                    // Coloca al controlador en la pila de navigacion
                    this.NavigationController.PushViewController(Controler, true);
                }
            };

            // Maneja navegacion mediante codigo (hay que poner el ID en las propriedades !)
            VerificarActividadButton.TouchUpInside += (sender, arg) =>
            {
                // Puede instanciarse el controlador con ID "CallHistoryControler" ?
                // establecido en el diseñador.
                if (this.Storyboard.InstantiateViewController("ValidacionControler") is ValidacionControler Controler)
                {
                    // Coloca al controlador en la pila de navigacion
                    this.NavigationController.PushViewController(Controler, true);
                }
            };

        }

        // Maneja la navegacion mediante Segues (deslizar el boton hacia la pantalla)
        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    // Se desea realizar la transicion a CallHistoryControler ?
        //    // Aqui ver Pattern Matching C# 7 !!!
        //    if (segue.DestinationViewController is CallHistoryControler Controler)
        //    {
        //        // Se proporciona la lista denumeros telefonicos al CallHistoryControler
        //        Controler.PhoneNumbers = PhoneNumbers;
        //    }
        //}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
               
        partial void VerifyButton_TouchUpInside(UIButton sender)
        {
            //Validate();
        }

        //private async void Validate()
        //{
        //    var Client = new SALLab05.ServiceClient();
        //    var Result = await Client.ValidateAsync("**********@hotmail.com", "p4$$W02d", this);

        //    var Alert = UIAlertController.Create("Resultado", 
        //        $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
        //        UIAlertControllerStyle.Alert);

        //    Alert.AddAction(UIAlertAction.Create("Ok",
        //        UIAlertActionStyle.Default, null));

        //    PresentViewController(Alert, true, null);

        //}
    }
}