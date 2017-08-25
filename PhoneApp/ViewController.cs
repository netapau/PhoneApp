using Foundation;
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

            // Maneja navegacion mediante codigo (hay que poner el ID en las propriedades del Controlador !)
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

            // Vamos a quitar el segue de la navigacion hacia la pantalla de validacion  !!!
            // El boton de navigacion se llama : VerificarActividadButton
            VerificarActividadButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                ValidControler ValidacionControler = this.Storyboard.InstantiateViewController("ValidControler") as ValidControler;
                if (ValidacionControler!=null)
                {
                    //this.NavigationController.PopToRootViewController(true);
                    this.NavigationController.PushViewController(ValidacionControler, true);
                    
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }
}