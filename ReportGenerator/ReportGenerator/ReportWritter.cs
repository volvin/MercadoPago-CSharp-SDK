using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoPagoSDK;

namespace ReportGenerator
{
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

        public abstract void WriteCollections(List<Collection> collections);

        public abstract void WriteMovements(List<Movement> movements);

        public abstract void WriteFooter();

        public abstract void WriteHeader(ReportTypes reportType, int numberOfRows);

        protected System.IO.StreamWriter _file = null;
        protected ProgressBar _progressBar = null;
    }
}
