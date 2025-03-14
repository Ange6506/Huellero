using DPFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huellero
{

    public partial class CapturaHuella : CaptureForm
    {
        public delegate void OnTemplateEventHadler(DPFP.Template template);
        public event OnTemplateEventHadler OnTemplate;
        private DPFP.Processing.Enrollment Enroller;

        protected override void Init()
        {
            base.Init();
            base.Text = "dar de alta huella";
            Enroller = new DPFP.Processing.Enrollment();
            UpdateStatus();
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            DPFP.FeatureSet feature = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            if (feature != null) try
                {
                    MakeReport("the fingerprint feature set was created1.");
                    Enroller.AddFeatures(feature);

                }
                finally
                {
                    UpdateStatus();

                    switch (Enroller.TemplateStatus)

                    {
                        case DPFP.Processing.Enrollment.Status.Ready:

                            OnTemplate(Enroller.Template);
                            SetPrompt("click close, and then click fingerPrint verification.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:

                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;

                    }
                }
        }

        private void UpdateStatus()
        {
            SetStatus(String.Format("FingerPrint samples peeded: {0}", Enroller.FeaturesNeeded));
        }

        public CapturaHuella()
        {
            InitializeComponent();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CapturaHuella_Load(object sender, EventArgs e)
        {

        }
    }
}
