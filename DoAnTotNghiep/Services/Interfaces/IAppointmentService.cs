using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment?> GetAppointmentById(int id);
        Task<Appointment> AddAppointment(AppointmentDto appointmentDto);
        Task<Appointment?> UpdateAppointment(int id, AppointmentDto appointmentDto);
        Task<bool> DeleteAppointment(int id);
    }
}
