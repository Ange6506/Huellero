using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Huellero
{
    /* NOTA: Este formulario es la base para EnrollmentForm y VerificationForm,
       Todos los cambios en CaptureForm se reflejarán en todos sus formularios derivados.
    */
    delegate void Function();

    public partial class CaptureForm : Form, DPFP.Capture.EventHandler
    {
        public CaptureForm()
        {
            InitializeComponent();
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture(); // Crear una operación de captura.

                if (null != Capturer)
                    Capturer.EventHandler = this; // Suscribirse a los eventos de captura.
                else
                    SetPrompt("¡No se puede iniciar la operación de captura!");
            }
            catch
            {
                MessageBox.Show("¡No se puede iniciar la operación de captura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void Process(DPFP.Sample Sample)
        {
            // Dibujar la imagen de la muestra de huella digital.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Usando el lector de huellas, escanea tu huella digital.");
                }
                catch
                {
                    SetPrompt("¡No se puede iniciar la captura!");
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("¡No se puede finalizar la captura!");
                }
            }
        }

        #region Manejadores de eventos del formulario:

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            Init();
            Start(); // Iniciar operación de captura.
        }

        private void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
        #endregion

        #region Implementación de EventHandler:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport("La muestra de huella digital fue capturada.");
            SetPrompt("Escanea la misma huella digital nuevamente.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El dedo fue retirado del lector de huellas.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huellas fue tocado.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huellas fue conectado.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huellas fue desconectado.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("La calidad de la muestra de huella digital es buena.");
            else
                MakeReport("La calidad de la muestra de huella digital es pobre.");
        }
        #endregion

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion(); // Crear un conversor de muestras.
            Bitmap bitmap = null; // TODO: el tamaño no importa
            Convertor.ConvertToPicture(Sample, ref bitmap); // TODO: devolver bitmap como resultado
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction(); // Crear un extractor de características
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features); // TODO: ¿devolver características como resultado?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate () {
                StatusLine.Text = status;
            }));
        }

        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate () {
                Prompt.Text = prompt;
            }));
        }
        protected void MakeReport(string message)
        {
            this.Invoke(new Function(delegate () {
                StatusText.AppendText(message + "\r\n");
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate () {
                Picture.Image = new Bitmap(bitmap, Picture.Size); // Ajustar la imagen al cuadro de imagen
            }));
        }

        public DPFP.Capture.Capture Capturer;
    }
}
