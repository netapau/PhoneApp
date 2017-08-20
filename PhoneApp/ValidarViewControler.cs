using Foundation;
using System;
using UIKit;

namespace PhoneApp
{
    public partial class ValidarViewControler : UITableViewController
    {
        public ValidarViewControler (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            

        }
    }

    private async void Validate()
    {
        var Client = new SALLab05.ServiceClient();
        var Result = await Client.ValidateAsync("**********@hotmail.com", "p4$$W02d", this);

        var Alert = UIAlertController.Create("Resultado",
            $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
            UIAlertControllerStyle.Alert);

        Alert.AddAction(UIAlertAction.Create("Ok",
            UIAlertActionStyle.Default, null));

        PresentViewController(Alert, true, null);

    }

}