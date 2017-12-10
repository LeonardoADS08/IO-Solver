﻿using System;
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
using System.Windows.Shapes;

namespace IO.Frames.Transporte
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        private bool _estado;
        private int _demandantes, _ofertantes;

        public int Demandantes { get => _demandantes; set => _demandantes = value; }
        public int Ofertantes{ get => _ofertantes; set => _ofertantes = value; }
        public bool Estado { get => _estado; set => _estado = value; }

        public Inicio()
        {
            InitializeComponent();
            _estado = false;
        }
        private void B_Aceptar_Click(object sender, RoutedEventArgs e)
        {

            if (Int32.TryParse(TB_Demandantes.Text, out _demandantes) &&
                Int32.TryParse(TB_Ofertantes.Text, out _ofertantes))
            {
                _estado = true;
                this.Close();
            }
            else MessageBox.Show(Utils.ErrorList.CantConvertToInt32, "Error en conversión.", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void B_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
