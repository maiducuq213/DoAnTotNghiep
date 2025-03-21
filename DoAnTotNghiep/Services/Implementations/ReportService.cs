namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    public class ReportService : IReportService
    {
        private readonly HospitalContext _context;

        public ReportService(HospitalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report> GetReportById(int id)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Report> AddReport(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<Report> UpdateReport(int id, Report report)
        {
            var existingReport = await _context.Reports.FindAsync(id);
            if (existingReport == null)
                return null;

            existingReport.ReportType = report.ReportType;
            existingReport.ReportContent = report.ReportContent;
            existingReport.GeneratedDate = report.GeneratedDate;

            await _context.SaveChangesAsync();
            return existingReport;
        }

        public async Task<bool> DeleteReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
                return false;

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        // 📌 Các hàm thống kê dữ liệu
        public async Task<int> GetTotalPatients()
        {
            return await _context.Patients.CountAsync();
        }

        public async Task<int> GetTotalAppointments()
        {
            return await _context.Appointments.CountAsync();
        }

        public async Task<int> GetTotalPayments()
        {
            return await _context.PaymentInvoices.CountAsync();
        }

        public async Task<int> GetAvailableBeds()
        {
            return await _context.Beds.CountAsync(b => b.Status ==BedStatus.Available);
        }

        // 📌 Tạo báo cáo tổng hợp dựa trên thống kê
        public async Task<Report> GenerateSummaryReport()
        {
            int totalPatients = await GetTotalPatients();
            int totalAppointments = await GetTotalAppointments();
            int totalPayments = await GetTotalPayments();
            int availableBeds = await GetAvailableBeds();

            string reportContent = $"📊 **Báo cáo tổng hợp**\n" +
                                   $"- Tổng số bệnh nhân: {totalPatients}\n" +
                                   $"- Tổng số lịch hẹn: {totalAppointments}\n" +
                                   $"- Tổng số thanh toán: {totalPayments}\n" +
                                   $"- Số giường bệnh còn trống: {availableBeds}";

            var report = new Report
            {
                ReportType = ReportTypeEnum.Summary,
                ReportContent = reportContent,
                GeneratedDate = DateTime.Now
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return report;
        }
    }
}
