using DemoCShap.Entityes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DemoCShap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

       
        private void HandleClick(object sender, RoutedEventArgs e)
        {
            var fullname = txtFullname.Text;
            var email = txtEmail.Text;
            var phone = txtPhone.Text;
            var password = txtPassword.PasswordChar.ToString();
            var student = new Student()
            {
                FullName = fullname,
                Email = email,
                Phone = phone,
                Password = password
            };
            Debug.WriteLine(student.ToString());
            
        }
    }
}
