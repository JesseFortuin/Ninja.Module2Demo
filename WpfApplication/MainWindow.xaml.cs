using NinjaDomain.Application;
using System.Windows;

namespace WpfApplication
{
    public partial class MainWindow : Window
    {
        private readonly INinjaFacade ninjaFacade;

        public MainWindow(INinjaFacade ninjaFacade)
        {
            InitializeComponent();


            this.ninjaFacade = ninjaFacade;
        }
        
        private void btnAddNinja_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.InsertNinja();

            MessageBoxResult result = MessageBox.Show("Ninja has been added", "Addition", MessageBoxButton.OK);
        }

        private void btnAddMultipleNinjas_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.InsertMultipleNinjas();

            MessageBoxResult result = MessageBox.Show("Ninjas have been added", "Addition", MessageBoxButton.OK);
        }

        private void btnNinjaQuery_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.SimpleNinjaQueries();

            MessageBoxResult result = MessageBox.Show("Ninja has been queried", "Query", MessageBoxButton.OK);
        }

        private void btnQueryAndUpdate_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.QueryAndUpdateNinja();

            MessageBoxResult result = MessageBox.Show("Ninja has been updated", "Update", MessageBoxButton.OK);
        }

        private void btnDisconnectedQueryAndUpdate_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.QueryAndUpdateNinjaDisconnected();

            MessageBoxResult result = MessageBox.Show("Ninja has been added Remotely", "Addition", MessageBoxButton.OK);
        }

        private void btnRetrieveUsingFind_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.RetrieveDataWithFind();

            MessageBoxResult result = MessageBox.Show("Ninja Found", "Query", MessageBoxButton.OK);
        }

        private void btnRetrieveStoredProc_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.RetrieveDataWithStoredProc();

            MessageBoxResult result = MessageBox.Show("Ninja Found", "Query", MessageBoxButton.OK);
        }

        private void btnRemoveNinja_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.RemoveNinja();

            MessageBoxResult result = MessageBox.Show("Ninja Removed", "Removal", MessageBoxButton.OK);
        }

        private void btnRemoveNinjaWithKeyValue_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.RemoveNinjaWithKeyValue();

            MessageBoxResult result = MessageBox.Show("Ninja Removed", "Removal", MessageBoxButton.OK);
        }

        private void btnRemoveNinjaViaStoredProc_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.RemoveNinjaViaStoredProcedure();

            MessageBoxResult result = MessageBox.Show("Ninja Removed", "Removal", MessageBoxButton.OK);
        }

        private void btnAddNinjaWithEquipment_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.InsertNinjaWithEquipment();

            MessageBoxResult result = MessageBox.Show("Ninja has been added with Equipment", "Addition", MessageBoxButton.OK);
        }

        private void btnNinjaGraphQuery_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.SimpleNinjaGraphQuery();

            MessageBoxResult result = MessageBox.Show("Ninja Found", "Query", MessageBoxButton.OK);
        }

        private void btnProjectionQuery_Click(object sender, RoutedEventArgs e)
        {
            ninjaFacade.ProjectionQuery();

            MessageBoxResult result = MessageBox.Show("Ninja Found", "Query", MessageBoxButton.OK);
        }
    }
}
