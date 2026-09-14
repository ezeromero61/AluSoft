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
    public partial class frm03_Cliente_2 : Form
    {
        public frm03_Cliente_2()
        {
            InitializeComponent();
        }
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void af_tabla_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(cbxIdPersona.SelectedValue);
            if (val != 0)
            {
                dataGridView1.DataSource = gpersona.Consultar(persona, val);//asistencia_alumnos.ListaAsistenciaAlumnosPorId(Convert.ToInt32(cbxIDasistencia.Text));
            }
            else
            {
                dataGridView1.DataSource = gpersona.ListarCatalogo();//asistencia_alumnos.ListaAsistenciaAlumnosSinId();
            }
        }

        private void af_buscar_Click(object sender, EventArgs e)
        {
            int val = int.Parse(cbxIdPersona.SelectedValue.ToString());
            if (val == 0)
            {
                MessageBox.Show("No existe registro para ese Alumno");
            }
            else
            {
                #region 07_Asistencias_Alumnos
                gcliente.ConsultarIdPersonaIdCliente(cliente,val);
                cliente.Idpersona = int.Parse(cbxIdPersona.SelectedValue.ToString());//(gpersona.Max(persona) + 1);
                cliente.Idlogin = cliente.Idlogin;
                cliente.Idcliente = cliente.Idcliente;
                txbNombre.Text= cliente.Nombre;
                txbApellido.Text= cliente.Apellido;
                dateTimePicker3.Text=Convert.ToString(cliente.Fecha_nacimiento);
                txbGenero.Text= cliente.Genero;
                txbDomicilio.Text= cliente.Domicilio;
                txbCorreo.Text= cliente.Correo;
                txbTelefono.Text=Convert.ToString(cliente.Telefono);
                txbDni.Text = Convert.ToString(cliente.Dni);
                txbLocalidad.Text= Convert.ToString(cliente.Localidad);
                cliente.Idrol = cliente.Idrol;
                dateTimePicker1.Text= Convert.ToString(cliente.Fecha_alta);
                dateTimePicker2.Value= DateTime.Today;
                txbCuil.Text= Convert.ToString(cliente.Cuil);
                #endregion
                gcliente.ConsultarIdPersonaIdCliente(cliente, val);
            }
        }

        private void frm03_Cliente_2_Load(object sender, EventArgs e)
        {
            #region Cliente
            cliente = new BE.cls03_Cliente();
            cbxIdPersona.DataSource = gcliente.ListarIdPersonaNombreApellido();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdPersona.DisplayMember = "Combo";
            cbxIdPersona.ValueMember = "IdPersona";
            cbxIdPersona.Text = null;
            #endregion
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            gcliente.ConsultarIdUsuario(cliente, cliente.Idpersona);
            int idcliente = cliente.Idcliente;
            int idlogin = cliente.Idlogin;
            int idrol = cliente.Idrol;
            int fa = 0;
            cliente = new BE.cls03_Cliente();
            cliente.Idpersona = int.Parse(cbxIdPersona.SelectedValue.ToString());//(gpersona.Max(persona) + 1);
            cliente.Idlogin = idlogin;
            cliente.Idcliente = idcliente;
            cliente.Nombre = (txbNombre.Text);
            cliente.Apellido = (txbApellido.Text);
            cliente.Fecha_nacimiento = DateTime.Parse(dateTimePicker3.Text);
            cliente.Genero = (txbGenero.Text);
            cliente.Domicilio = (txbDomicilio.Text);
            cliente.Correo = txbCorreo.Text;
            cliente.Telefono = int.Parse(txbTelefono.Text);
            cliente.Dni = int.Parse(txbDni.Text);
            cliente.Localidad = (txbLocalidad.Text);
            cliente.Idrol = idrol;
            cliente.Fecha_alta = DateTime.Parse(dateTimePicker1.Text);
            cliente.Fecha_baja = DateTime.Parse(dateTimePicker2.Text);
            cliente.Cuil = double.Parse(txbCuil.Text);
            fa = gcliente.Editar(cliente);
            if (fa != 0)
            {
                MessageBox.Show("Se agrego");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 4;
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

        private void af_limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control controles in groupBox2.Controls)
            {
                if (controles is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                    texbox.Text = string.Empty;
                }
                else if (controles is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                    cbx.Text = string.Empty;
                }
            }
            foreach (Control controles in groupBox1.Controls)
            {
                if (controles is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                    texbox.Text = string.Empty;
                }
                else if (controles is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                    cbx.Text = string.Empty;
                    cbx.SelectedValue = 0;
                }
            }
            dataGridView1.DataSource = null;
        }

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?. Are you sure you want to delete this item?. Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmar eliminación. Confirm delete. Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Comprobar el resultado del cuadro de mensaje
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Se han eliminado " + gcliente.Eliminar(cliente) + " filas");
                foreach (Control controles in groupBox2.Controls)
                {
                    if (controles is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                        texbox.Text = string.Empty;
                    }
                    else if (controles is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                        cbx.Text = string.Empty;
                    }
                }
                foreach (Control controles in groupBox1.Controls)
                {
                    if (controles is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                        texbox.Text = string.Empty;
                    }
                    else if (controles is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                        cbx.Text = string.Empty;
                        cbx.SelectedValue = 0;
                    }
                }
                dataGridView1.DataSource = null;
            }
            else
            {
            }
        }
    }
}
