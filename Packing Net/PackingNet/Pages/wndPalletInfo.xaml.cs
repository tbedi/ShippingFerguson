using Packing_Net.Classes;
using PackingClassLibrary;
using PackingClassLibrary.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PackingNet.Pages
{
    /// <summary>
    /// Interaction logic for wndPalletInfo.xaml
    /// </summary>
    public partial class wndPalletInfo : Window
    {

        DispatcherTimer _threadPrint = new DispatcherTimer();

        smController _Contro = new smController();

        public wndPalletInfo()
        {
            InitializeComponent();
            _threadPrint.Interval = new TimeSpan(0, 0, 3);
            _threadPrint.Start();
            _threadPrint.Tick += _threadPrint_Tick;
        }

        void _threadPrint_Tick(object sender, EventArgs e)
        {
            //Print functions.
            _print();
            //Stop Double priting 
            _threadPrint.Stop();
            //Close this window.
            this.Close();

        }
        private void _print()
        {
            try
            {

                PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
                printDlg.PrintTicket.PageMediaSize = new PageMediaSize((Double)410.0, (Double)581.0);
                //printDlg.ShowDialog();

                //get selected printer capabilities
                System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);

                //get scale of the print wrt to screen of WPF visual
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.Width, capabilities.PageImageableArea.ExtentHeight / this.Height);

                //Transform the Visual to scale
                this.LayoutTransform = new ScaleTransform(scale, scale);

                //get the size of the printer page
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                //update the layout of the visual to the printer page size.
                this.Measure(sz);

                this.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(this, "BoxSlip_KrausUSA_A");
            }
            catch (Exception)
            {

            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            cstShippingTbl lstshipping = new cstShippingTbl();

            lstshipping = _Contro.GetShippingTbl(Global.ShipmentNumberforferguson);

            lblFromAddress.Text = lstshipping.FromAddressLine1 + " " + lstshipping.FromAddressLine2 + " " + lstshipping.FromAddressLine3 + " " + lstshipping.FromAddressCity + " " + lstshipping.FromAddressState + " " + lstshipping.FromAddressCountry + " " + lstshipping.FromAddressZipCode;

            lblCarrier.Text = lstshipping.Carrier;

            lblPonumber.Text = lstshipping.CustomerPO;

            lblToAddress.Text =lstshipping.CustomerName1+" "+ lstshipping.ToAddressLine1 + " " + lstshipping.ToAddressLine2 + " " + lstshipping.ToAddressLine3 + " " + lstshipping.ToAddressCity + " " + lstshipping.ToAddressState + " " + lstshipping.ToAddressCountry + " " + lstshipping.ToAddressZipCode;

        }

    }
}
