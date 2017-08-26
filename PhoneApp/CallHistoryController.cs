using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneApp
{
    public partial class CallHistoryController : UITableViewController
    {
        public List<string> PhoneNumbers { get; set; }

        protected NSString CallHistoryCellID = new NSString("CallHistoryCell");

        public CallHistoryController(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CallHistoryCellID);
            TableView.Source = new CallHistoryDataSource(this);
        }

        class CallHistoryDataSource : UITableViewSource
        {
            CallHistoryController Controler;

            public CallHistoryDataSource(CallHistoryController controler)
            {
                // Almacenar la instancia del UITableViewController
                this.Controler = controler;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                // Devuelve un UITableViewCell reutilizable creado con el identificador
                // Controler.CallHistoryCellID
                var cell = tableView.DequeueReusableCell(Controler.CallHistoryCellID);

                cell.TextLabel.Text = Controler.PhoneNumbers[indexPath.Row];

                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Controler.PhoneNumbers.Count;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}