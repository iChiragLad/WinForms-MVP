using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MVP_Pattern
{
    public partial class CarView : Form, ICarView
    {
        public CarView()
        {
            InitializeComponent();
            object obj = Activator.CreateInstance(typeof(Color));
            Type t = typeof(Color);
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo p in props)
            {
                cmbColor.Items.Add(p.GetValue(obj));
            }
        }

        public Color ColorCode
        {
            get
            {
                return (Color)cmbColor.SelectedItem;
            }

            set
            {
                cmbColor.SelectedItem = value;
            }
        }

        public string Make
        {
            get
            {
                return txtMake.Text;
            }

            set
            {
                txtMake.Text = value;
            }
        }

        public string Model
        {
            get
            {
                return txtModel.Text;
            }

            set
            {
                txtModel.Text = value;
            }
        }

        public int OwnerID
        {
            get
            {
                return Convert.ToInt32(txtOwnerID.Text);
            }

            set
            {
                txtOwnerID.Text = (value).ToString();
            }
        }

        public int YOP
        {
            get
            {
                return Convert.ToInt32(txtYOP.Text);
            }

            set
            {
                txtYOP.Text = (value).ToString();
            }
        }

        public event EventHandler Add;
        public event EventHandler Modify;
        public event EventHandler Open;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Add != null)
            {

                Add(this, EventArgs.Empty);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(Open != null)
            {
                Open(this, EventArgs.Empty);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(Modify != null)
            {
                Modify(this, EventArgs.Empty);
            }
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtColor.BackColor = (Color)cmbColor.SelectedItem;
        }
    }
}
