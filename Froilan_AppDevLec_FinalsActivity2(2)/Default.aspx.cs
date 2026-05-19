using DataHelper;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Froilan_AppDevLec_FinalsActivity2_2_
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                loadReport();

        }

        public void loadReport()
        {
            try
            {
                DataAccess db = new DataAccess();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/StudentReport.rdlc");

                //fetch datatables
                DataTable dtCourseCount = db.GetCourseCounts();
                DataTable dtPassedFailed = db.GetCountPassedFailed();
                DataTable dtAverage = db.DisplayAverage();

                Microsoft.Reporting.WebForms.ReportDataSource rdsCourse = new Microsoft.Reporting.WebForms.ReportDataSource("ds_CountCourse", dtCourseCount);
                Microsoft.Reporting.WebForms.ReportDataSource rdsPassedFailed = new Microsoft.Reporting.WebForms.ReportDataSource("ds_CountPassedFailed", dtPassedFailed);
                Microsoft.Reporting.WebForms.ReportDataSource rdsAverage = new Microsoft.Reporting.WebForms.ReportDataSource("ds_DisplayAverage", dtAverage);



                ReportViewer1.LocalReport.DataSources.Add(rdsCourse);
                ReportViewer1.LocalReport.DataSources.Add(rdsPassedFailed);
                ReportViewer1.LocalReport.DataSources.Add(rdsAverage);

                ReportViewer1.LocalReport.Refresh();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('Error generating report: " + ex.Message + "');</script>");
            }
        }
    }
}