using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WIFIGUIDemo
{
    public partial class EObjectsForm : Form
    {
        public EObjectsForm()
        {
            InitializeComponent();
        }

        int deliveredObjectsCounter = 0;

        private void deliveredButton_Click(object sender, EventArgs e)
        {
            deliveredObjectsCounter++;
            deliveredObjects.Text = "Object Delivered: " + deliveredObjectsCounter.ToString();
        }

        private void missDeliveredButton_Click(object sender, EventArgs e)
        {
            deliveredObjectsCounter--;
            if (deliveredObjectsCounter < 0) deliveredObjectsCounter = 0;
            deliveredObjects.Text = "Object Delivered: " + deliveredObjectsCounter.ToString();
        }
    }
}
