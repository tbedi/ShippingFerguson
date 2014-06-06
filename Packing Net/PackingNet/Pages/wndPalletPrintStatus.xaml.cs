using PackingClassLibrary;
using PackingClassLibrary.CustomEntity.SMEntitys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PackingNet.Pages
{
    /// <summary>
    /// Interaction logic for wndPalletPrintStatus.xaml
    /// </summary>
    public partial class wndPalletPrintStatus : Window
    {
        smController _Contro = new smController();

        public wndPalletPrintStatus()
        {
            InitializeComponent();
        }

        private void btnAddNewBox_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void txtBoxNumberScanned_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxNumberScanned.Text = "";
        }

        private void txtBoxNumberScanned_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    foreach (DataGridRow row in GetDataGridRows(grdContent))
                    {
                        TextBlock txtBoxNum = grdContent.Columns[0].GetCellContent(row) as TextBlock;
                        if (txtBoxNum.Text == txtBoxNumberScanned.Text)
                        {
                            TextBlock txtstatus = grdContent.Columns[1].GetCellContent(row) as TextBlock;
                            txtstatus.Text = "Printed";
                        }
                    }
                }));
            }
        }

        private void txtSHNumber_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               List<cstPalletInfo> _lspallet = new List<cstPalletInfo>();
                _lspallet=_Contro.GetPalletInfoBySHNumber(txtSHNumber.Text);
                grdContent.ItemsSource = _lspallet;
            }
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
    }
}
