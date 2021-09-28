using IDQ.Domain.Base;
using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.EntityFramework.Services;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.Views.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IDQ.WPF.Shared
{
    public class GlobalVars
    {
        public static string colorWindowBackgroundOK =>  "DarkGreen";
        public static string colorWindowBackkgroundNO => "Red";
        public static string strFecha => DateTime.Today.ToString(@"yyyy/MM/dd");
        public static string strHora => DateTime.Now.ToString(@"HH:mm:ss");


        public static usuarioModel usuarioLogueado;


        public static void nextTarget(object sender, bool reverse = false)
        {
            if (sender != null)
            {
                FocusNavigationDirection direction = FocusNavigationDirection.Next; if (reverse) { direction = FocusNavigationDirection.Previous; }

                Control ctrl = (Control)sender;
                _ = ctrl.Focus();

                _ = ctrl.MoveFocus(new TraversalRequest(direction));
            }
        }

        public static void contabilizarCaja(cajaModel sentCaja, bool sentDescontar = false)
        {
            if (sentDescontar)
            {
                context.globalCajaActual.Efectivo -= Math.Round(sentCaja.Efectivo, 2);
                context.globalCajaActual.MercadoPago -= Math.Round(sentCaja.MercadoPago, 2);
            }
            else
            {
                context.globalCajaActual.Efectivo += Math.Round(sentCaja.Efectivo - sentCaja.Vuelto, 2);
                context.globalCajaActual.MercadoPago += Math.Round(sentCaja.MercadoPago, 2);
            }
        }

        public static fechaModel returnFecha()
        {
            try { return context.globalDb.fechas.Local.Single(x => x.Fecha == strFecha); }
            catch { return new fechaModel() { Fecha = strFecha }; }
        }

        public static void resetProductoAgregado()
        {
            foreach (productoModel prd in context.globalDb.productos.Local.Where(x => x.Agregado))
            {
                prd.Agregado = false;
            }
        }

        public class messageError
        {
            #region Confirmación
            public static void Guardado() { /*MessageBox.Show("Item guardado", "Guardar");*/ }

            public static void StockRecalcular() { MessageBox.Show("Stock recalculado.", "Stock"); }

            public static bool NewProduct() { return MessageBox.Show("El producto no existe, desea agregarlo?", "Producto no existente", MessageBoxButton.YesNo) == MessageBoxResult.Yes; }

            public static bool AreYouSure() { return MessageBox.Show("Esta seguro que desea realizar esta modificación?", "Esta seguro?", MessageBoxButton.YesNo) == MessageBoxResult.Yes; }
            #endregion // Confirmación



            #region Errores
            public static void Usuario() { MessageBox.Show("Ya existe un registro con el mismo Usuario.", "Error Usuario"); }

            public static void LogIn() { MessageBox.Show("Usuario o contraseña incorrectos.", "Error Usuario/Contraseña"); }

            public static void Existencia() { MessageBox.Show("Ya existe un Item de éste tipo.", "Error Medida"); }

            public static void FechaErronea() { MessageBox.Show("El recuadro fecha no contiene una fecha válida.", "Error fecha"); }

            public static void CodigoExiste() { MessageBox.Show("Ya existe un producto con éste código.", "Código Duplicado"); }

            public static void CodigoNoExiste() { MessageBox.Show("No existe producto registrado con ese código", "Código Erroneo"); }
            #endregion // Errores
        }
    }
}
