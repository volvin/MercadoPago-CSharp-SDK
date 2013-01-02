/*
 * Copyright 2012 MercadoLibre, Inc.
 *
 * Changed to retrieve a well-formed json string running .ToString() method.
 * Allows to serialize scalar data at CreateFromString method.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

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

    /// <summary>
    /// A representation of the abstract Report Writter resource. 
    /// </summary>
    public abstract class ReportWritter
    {
        /// <summary>
        /// Create a new Report Writter instance.
        /// </summary>
        public ReportWritter()
        { }

        /// <summary>
        /// Create a new Report Writter instance.
        /// </summary>
        /// <param name="file">The destination file
        /// </param>
        public ReportWritter(System.IO.StreamWriter file)
        {
            _file = file;
        }

        // Delegates to control UI updates
        public delegate void IncreaseProgressBarValueCallback();
        public delegate void UpdateProgressTextValueCallback(string text);

        /// <summary>
        /// File field.
        /// </summary>
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

        /// <summary>
        /// ProgressBar field.
        /// </summary>
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

        /// <summary>
        /// ProgressText field.
        /// </summary>
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

        /// <summary>
        /// Status field.
        /// </summary>
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

        // A list of methods to override in the implements class
        public abstract void WriteCollections(List<Collection> collections);
        public abstract void WriteFooter();
        public abstract void WriteHeader(ReportTypes reportType, int numberOfRows);
        public abstract void WriteMovements(List<Movement> movements);

        #region "Private Members"

        protected System.IO.StreamWriter _file = null;
        protected ProgressBar _progressBar = null;
        protected Label _progressText = null;
        protected ReportWritterStatuses _status = ReportWritterStatuses.Active;

        /// <summary>
        /// Increases progress bar.
        /// </summary>
        protected void IncreaseProgressBarValue()
        {
            try
            {
                _progressBar.Value += 1;
            }
            catch
            { }
        }

        /// <summary>
        /// Changes progress text value.
        /// </summary>
        protected void UpdateProgressTextValue(string text)
        {
            _progressText.Text = text;
        }

        #endregion
    }
}
