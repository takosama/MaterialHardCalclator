using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialHardCalclator
{
    public partial class MaterialForm : UserControl
    {
        Material m;
        public MaterialForm()
        {
            InitializeComponent();
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {

        }

        public void SetValue(Material material)
        {
            this.textBox3.Text = material.Density.ToString();
            this.textBox2.Text = material.Young.ToString();
            this.m = new Material();
            m.Name = material.Name;
            m.Density = material.Density;
            m.Young = material.Young;
        }

        public Material GetValue()
        {
            try
            {
                string name = m.Name;
                var Young = double.Parse(textBox2.Text);
                var Density = double.Parse(textBox3.Text);
                var rtn = new Material();
                rtn.Name = name;
                rtn.Young = Young;
                rtn.Density = Density;
                return rtn;
            }
            catch { return m; }
        }
    }
}
