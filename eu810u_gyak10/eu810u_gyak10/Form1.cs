﻿using eu810u_gyak10.Entities;
using eu810u_gyak10.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eu810u_gyak10
{
    public partial class Form1 : Form
    {
        BindingList<Child> children = new BindingList<Child>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = children;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var c = new Child();

            var behaviour = int.Parse(txtBehaviour.Text);

            if (!c.CheckBehaviour(behaviour))
            {
                MessageBox.Show("Helytelen érték, csak 1-5 közötti szám adható meg!");
                return;
            }

            c.Name = txtName.Text;
            c.YearlyBehaviour = (Behaviour)behaviour;

            children.Add(c);
        }
	
    }
}
