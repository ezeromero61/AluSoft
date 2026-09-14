using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    public partial class frm00_Persona : Form
    {
        public frm00_Persona()
        {
            InitializeComponent();
        }
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            persona = new BE.cls00_Persona();
            persona.Idpersona = (gpersona.Max(persona) + 1);
            persona.Idlogin = int.Parse(txbNombre.Text);
            persona.Nombre = (txbNombre.Text);
            persona.Apellido = (txbDescripcion.Text);
            persona.Fecha_nacimiento = DateTime.Parse(dateTimePicker3.Text);
            persona.Genero = (txbAlto.Text);
            persona.Domicilio = (txtAncho.Text);
            persona.Correo = txtAncho.Text;
            persona.Telefono = int.Parse(txtMaterial.Text);
            persona.Dni = int.Parse(txtColor.Text);
            persona.Localidad = (textBox7.Text);
            persona.Idrol = int.Parse(txbLargo.Text);
            persona.Fecha_alta = DateTime.Parse(dateTimePicker1.Text);
            persona.Fecha_baja = DateTime.Parse(dateTimePicker2.Text);
            persona.Cuil = int.Parse(textBox4.Text);
            fa = gpersona.Agregar(persona);

            if (fa != 0)
            {
                MessageBox.Show("Se agrego");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 1;
                bitacora.idaccion = 1;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = Convert.ToDateTime(DateTime.Now.TimeOfDay);
                fa = gbitacora.Agregar(bitacora);
                #endregion
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void frm00_Persona_Load(object sender, EventArgs e)
        {


        }
    }
}
