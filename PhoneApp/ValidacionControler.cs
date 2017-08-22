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

         class ValidacionDataSource : UITableViewSource
        {
            ValidacionControler Controler;

            public ValidacionDataSource(ValidacionControler controler)
            {
                // Almacenar la instancia del UITableViewController
                this.Controler = controler;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                //throw new NotImplementedException();
                // Devuelve un UITableViewCell reutilizable creado con el identificador
                // Controler.CallHistoryCellID
                //var cell = tableView.DequeueReusableCell(Controler.CallHistoryCellID);

                //cell.TextLabel.Text = Controler.PhoneNumbers[indexPath.Row];

                return null;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return 0;  //Controler.PhoneNumbers.Count;
            }
        }

            public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
        
        private async void Valida()
        {
            var Client = new SALLab06.ServiceClient();
            var Result = await Client.ValidateAsync(CorreoTxt.Text, ContrasenhaTxt.Text, this);

            var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token}", UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(Alert, true, null);
        }

        partial void ValidacionButton_TouchUpInside(UIButton sender)
        {
            Valida();
        }
    }
}