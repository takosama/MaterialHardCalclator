using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialHardCalclator
{
    public partial class Form1 : Form
    {
        Material SelectedMaterial = null;
        Material[] materials = null;
        Element[] elements = null;
        Function[] functions = null;
        MaterialForm MaterialForm = new MaterialForm();
        double selectedDanseiMoment = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           materials = Materials.GetMaterials();
            elements = Elements.GetElements();
            functions = Functions.GetFunctions();

            this.comboBox1.Items.AddRange(materials.Select(x => x.Name).ToArray());
            this.comboBox2.Items.AddRange(elements.Select(x => x.Name).ToArray());
            this.comboBox3.Items.AddRange(functions.Select(x => x.Name).ToArray());
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            this.panel1.Controls.Add(MaterialForm);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = materials.First(x => x.Name == (string)comboBox1.Items[comboBox1.SelectedIndex]);
            MaterialForm.SetValue(m);
            this.SelectedMaterial = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SelectedMaterial = MaterialForm.GetValue();
        }


        List<Label> labels;
        List<TextBox> texts;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ele = elements.First(x => x.Name == (string)comboBox2.Items[comboBox2.SelectedIndex]);
            labels = new List<Label>();
            texts = new List<TextBox>();
            int num = ele.Values.Length;

            panel2.Controls.Clear();
            panel2.AutoScroll = true;
            for(int i=0;i<num;i++)
                {
                var l = new Label();
                l.Text = ele.Values[i].ToString();
                l.Location = new Point(10, 10 + i * 20);
                l.Height = 20;
                l.Width = l.Text.Length * 12+5;
               
                var t = new TextBox();
                t.Location = new Point(l.Text.Length * 15<=150?150: l.Text.Length * 12+5, 10 + i * 20);
                t.Height = 20;
                t.Width = 11 * 10;

                labels.Add(l);
                texts.Add(t);
                panel2.Controls.Add(l);
                panel2.Controls.Add(t);
            }

        
        
    }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                var vals = texts.Select(x => x.Text).Select(x => double.Parse(x)).ToArray();
                var nams = labels.Select(x => x.Text).ToArray();
                var _ = nams.Zip(vals, (a, b) => (a, b)).ToArray();

                var el = elements.First(x => x.Name == (string)comboBox2.Items[comboBox2.SelectedIndex]);

                var val = el.ComputeDanseiMoment(_);
                this.selectedDanseiMoment = val;
                //                var val=  ele.ComputeKatamotiSentanTawami(_, this.SelectedMaterial);
            
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }

            try
            {
                var vals=texts3.Select(x => x.Text).Select(x => double.Parse(x)).ToArray();
                var nams = labels3.Select(x => x.Text).ToArray();
        var _=        nams.Zip(vals, (a, b) => (a, b)).ToArray();

             var ele=   functions.First(x => x.Name == (string)comboBox3.Items[comboBox3.SelectedIndex]);

                var val = ele.ComputeHizumi(_,this.selectedDanseiMoment,this.SelectedMaterial);
          
//                var val=  ele.ComputeKatamotiSentanTawami(_, this.SelectedMaterial);
if(val*10<1)
                Console.WriteLine(val*1000+"mm");
else
                    Console.WriteLine(val+"m");
                this.textBox1.Text = val.ToString();
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }

        List<Label> labels3;
        List<TextBox> texts3;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ele = functions.First(x => x.Name == (string)comboBox3.Items[comboBox3.SelectedIndex]);
            labels3 = new List<Label>();
            texts3 = new List<TextBox>();
            int num = ele.Values.Length;

            panel3.Controls.Clear();
            panel3.AutoScroll = true;
            for (int i = 0; i < num; i++)
            {
                var l = new Label();
                l.Text = ele.Values[i].ToString();
                l.Location = new Point(10, 10 + i * 20);
                l.Height = 20;
                l.Width = l.Text.Length * 12 + 5;

                var t = new TextBox();
                t.Location = new Point(l.Text.Length * 15 <= 150 ? 150 : l.Text.Length * 12 + 5, 10 + i * 20);
                t.Height = 20;
                t.Width = 11 * 10;

                labels3.Add(l);
                texts3.Add(t);
                panel3.Controls.Add(l);
                panel3.Controls.Add(t);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string val = "";
            try
            {
                var vals = texts.Select(x => x.Text).ToArray();
                var nams = labels.Select(x => x.Text).ToArray();
                var _ = nams.Zip(vals, (a, b) => (a, b)).ToArray();

                var el = elements.First(x => x.Name == (string)comboBox2.Items[comboBox2.SelectedIndex]);

               val = el.Computex(_);
              
                //                var val=  ele.ComputeKatamotiSentanTawami(_, this.SelectedMaterial);

            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }

            try
            {
                var vals = texts3.Select(x => x.Text).ToArray();
                var nams = labels3.Select(x => x.Text).ToArray();
                var _ = nams.Zip(vals, (a, b) => (a, b)).ToArray();

                var ele = functions.First(x => x.Name == (string)comboBox3.Items[comboBox3.SelectedIndex]);

                var va = ele.Computex(_,val, this.SelectedMaterial,double.Parse( this.textBox1.Text));
                
                //                var val=  ele.ComputeKatamotiSentanTawami(_, this.SelectedMaterial);
                this.textBox2.Text = va.ToString();
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }
    }
}
