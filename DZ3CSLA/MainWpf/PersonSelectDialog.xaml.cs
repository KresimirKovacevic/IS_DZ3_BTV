﻿using System;
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

namespace UpravljanjeProjektima
{
  public partial class PersonSelectDialog : Window
  {

    public int personId
    {
      get { return ((PersonInfo)listViewPeople.SelectedItem).PersonId; }
    }

    public PersonSelectDialog()
    {
      InitializeComponent();
    }

    private void Select(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }



  }
}
