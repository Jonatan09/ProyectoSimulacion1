using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODELOS_DISCRETOS_CONTINUOS
{
    class Validar
    {
        public static void SoloLetras(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsLetter(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                }
            }
            catch (Exception e)
            {

            }

        }

        public static void SoloNumeros(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsDigit(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;
                    MessageBox.Show("Ingrese solo Numeros", "Dato Erroneo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

            }

        }
        public static void NumerosDecimal(KeyPressEventArgs v)
        {
            try
            {
                if (char.IsDigit(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsSeparator(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (char.IsControl(v.KeyChar))
                {
                    v.Handled = false;
                }
                else if (v.KeyChar.ToString().Equals("."))
                {
                    v.Handled = false;
                }
                else
                {
                    v.Handled = true;

                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
