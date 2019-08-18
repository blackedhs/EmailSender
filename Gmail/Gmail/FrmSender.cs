using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EnvioMails;

namespace Gmail
{
    public partial class FrmSender : Form
    {
        private ManejadorEmails manejador;
        public FrmSender()
        {
            InitializeComponent();
            manejador = new ManejadorEmails();
            CargaChk();
        }
        public void CargaChk()
        {
            string path = Environment.CurrentDirectory + "\\base_Xml.xml";
            if (Directory.Exists(path))
                return;
            try
            {
                manejador.Emails = new XML().Abrir(path);
            }
            catch (MiException miexec)
            {
                MessageBox.Show(miexec.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (Email email in manejador.Emails)
            {
                chkEmails.Items.Add(email);
                manejador.Cant++;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmAgregar frm = new FrmAgregar(manejador);
            frm.Show();
            frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ActualizarChk);
        }

        private void ActualizarChk(object sender, EventArgs e)
        {
            chkEmails.Items.Clear();
            foreach (Email email in manejador.Emails)
            {
                chkEmails.Items.Add(email);
            }
        }

        private void BrnEliminar_Click(object sender, EventArgs e)
        {
            if (chkEmails.CheckedItems.Count == 0)
                MessageBox.Show("Debe seleccionar un elemento");
            else
            {
                foreach (Email email in chkEmails.CheckedItems)
                {
                    if (manejador - email)
                        MessageBox.Show(email.DireccionEmail + " --Eliminado--");
                }
                ActualizarChk(sender, e);
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < manejador.Cant; i++)
            {
                chkEmails.SetItemChecked(i, true);
            }
        }

        private void BtnCancelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < manejador.Cant; i++)
            {
                chkEmails.SetItemChecked(i, false);
            }
        }

        private void FrmSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\base_Xml.xml";
            new XML().Guardar(manejador.Emails, path);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            ProcesoPrincipal.Instancia.Comenzar(new Dato(txtEmail.Text, txtContraseña.Text, string.Empty, string.Empty, manejador.Emails));
        }
    }

}
