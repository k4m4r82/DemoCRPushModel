using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DemoCRPushModel.Dao;
using DemoCRPushModel.Model;
using DemoCRPushModel.Report;

namespace DemoCRPushModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadReport();
        }

        private void LoadReport()
        {
            IList<Siswa> recordSiswa = null;
            using (var dao = new SiswaDao())
            {
                recordSiswa = dao.GetAll();
            }

            var reportSiswa = new CrSiswa();
            reportSiswa.Database.Tables["Siswa"].SetDataSource(recordSiswa);

            crystalReportViewer1.ReportSource = reportSiswa;
        }
    }
}
