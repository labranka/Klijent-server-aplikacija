using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormServer : Form
    {
        Server s;
       
        public FormServer()
        {
            InitializeComponent();
        }

    

        private void FormServer_Load(object sender, EventArgs e)
        {
            s = new Server();
            if (s.pokreniServer())
            {
                this.Text = " Server je pokrenut!";

                
            }
        }

       
    }
}
