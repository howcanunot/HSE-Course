using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Fractal : Form
    {
        public Fractal()
        {
            InitializeComponent();
            this.MaximumSize = new Size(ScreenFeatures.MinWidth, ScreenFeatures.MinHeight);
            this.MinimumSize = new Size(ScreenFeatures.MinWidth, ScreenFeatures.MinHeight);

        }
        
        private void FactorialLoad(object sender, EventArgs e)
        {

        }

        private void FractTreeClick(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(fractTreeLabel.Text);
            //settingsForm.SetFractalName(fractTreeLabel.Text);
            this.Visible = false;
            settingsForm.ShowDialog();

        }

        private void KokhKurveClick(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(kokhCurveLabel.Text);
            //settingsForm.SetFractalName(kokhCurveLabel.Text);
            this.Visible = false;
            settingsForm.ShowDialog();
        }

        private void SerpinskyCarpetClick(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(serpinskyCarpetLabel.Text);
            //settingsForm.SetFractalName(serpinskyCarpetLabel.Text);
            this.Visible = false;
            settingsForm.ShowDialog();
        }

        private void SerpinskyTriagClick(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(serpinskyTriagLabel.Text);
           // settingsForm.SetFractalName(serpinskyTriagLabel.Text);
            this.Visible = false;
            settingsForm.ShowDialog();
        }

        private void KantorSetClick(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(kantorSetLabel.Text);
            //settingsForm.SetFractalName(kantorSetLabel.Text);
            this.Visible = false;
            settingsForm.ShowDialog();
        }
    }
}
