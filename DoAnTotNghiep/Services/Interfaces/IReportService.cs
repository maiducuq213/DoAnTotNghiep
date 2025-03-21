using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetAllReports();
        Task<Report> GetReportById(int id);
        Task<Report> AddReport(Report report);
        Task<Report> UpdateReport(int id, Report report);
        Task<bool> DeleteReport(int id);

        // Thống kê số lượng bệnh nhân, lịch hẹn, thanh toán, giường bệnh, v.v.
        Task<int> GetTotalPatients();
        Task<int> GetTotalAppointments();
        Task<int> GetTotalPayments();
        Task<int> GetAvailableBeds();

        // Tạo báo cáo tổng hợp
        Task<Report> GenerateSummaryReport();
    }
}
