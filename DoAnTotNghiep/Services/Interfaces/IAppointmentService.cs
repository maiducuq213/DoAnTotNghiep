using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointment(int id, Appointment appointment);
        Task<bool> DeleteAppointment(int id);
    }
}
