using System.Windows;

namespace IDQ.WPF.Shared
{
    class GlobalErrors
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
