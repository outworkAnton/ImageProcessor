using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Contract.Interfaces;

namespace BulkCopier
{
    public partial class MainForm : Form
    {
        private readonly ICopyFilesService _service;

        public MainForm(ICopyFilesService service)
        {
            _service = service;
            InitializeComponent();
        }
    }
}
