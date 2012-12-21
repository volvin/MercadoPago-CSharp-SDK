using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoPagoSDK;

namespace ReportGenerator
{
    public enum ReportWritterStatuses
    { 
        Active,
        Terminated
    }

    public abstract class ReportWritter
    {
        public ReportWritter()
        { }

        public ReportWritter(System.IO.StreamWriter file)
        {
            _file = file;
        }

        public virtual System.IO.StreamWriter File
        {
            get
            {
                return _file;
            }

            set 
            {
                _file = value;
            }
        }

        public virtual ProgressBar ProgressBar
        {
            get
            {
                return _progressBar;
            }

            set
            {
                _progressBar = value;
            }
        }

        public virtual Label ProgressText
        {
            get
            {
                return _progressText;
            }

            set
            {
                _progressText = value;
            }
        }

        public virtual ReportWritterStatuses Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public delegate void IncreaseProgressBarValueCallback();

        protected void IncreaseProgressBarValue()
        {
            _progressBar.Value += 1;
        }

        public delegate void UpdateProgressTextValueCallback(string text);

        protected void UpdateProgressTextValue(string text)
        {
            _progressText.Text = text;
        }

        public abstract void WriteCollections(List<Collection> collections);

        public abstract void WriteMovements(List<Movement> movements);

        public abstract void WriteFooter();

        public abstract void WriteHeader(ReportTypes reportType, int numberOfRows);

        protected System.IO.StreamWriter _file = null;
        protected ProgressBar _progressBar = null;
        protected Label _progressText = null;
        protected ReportWritterStatuses _status = ReportWritterStatuses.Active;
    }
}
