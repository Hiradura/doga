using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1.Data;

namespace schoolPaper.View
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        private readonly VContent _context;
        private Emberek _selectedUser;

        public DataView()
        {
            InitializeComponent();
            _context = new VContent();
            LoadData();
        }

        private void LoadData()
        {
            var users = _context.Emberek.ToList();
            listBox.ItemsSource = users;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                _selectedUser = (Emberek)listBox.SelectedItem;
                nevTextbox.Text = _selectedUser.Nev;
                korTextbox.Text = _selectedUser.Kor;
                varosTextbox.Text = _selectedUser.Varos;
                meloTextbox.Text = _selectedUser.Melo;
                hobbiTextbox.Text = _selectedUser.Hobbi;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _selectedUser.Nev = nevTextbox.Text;
                _selectedUser.Kor = korTextbox.Text;
                _selectedUser.Varos = varosTextbox.Text;
                _selectedUser.Melo = meloTextbox.Text;
                _selectedUser.Hobbi = hobbiTextbox.Text;

                _context.Emberek.Update(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _context.Emberek.Remove(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            nevTextbox.Text = "";
            korTextbox.Text = "";
            varosTextbox.Text = "";
            meloTextbox.Text = "";
            hobbiTextbox.Text = "";
        }

        private void ageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
