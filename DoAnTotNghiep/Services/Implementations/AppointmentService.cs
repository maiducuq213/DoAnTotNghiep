namespace DoAnTotNghiep.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    using DoAnTotNghiep.DTOs;

    public class AppointmentService: IAppointmentService
    {
        private readonly HospitalContext _context;

        public AppointmentService(HospitalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentById(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<Appointment> AddAppointment(AppointmentDto appointmentDto)
        {
            var createAppointment = new Appointment
            {
                Status = appointmentDto.Status,
                Note = appointmentDto.Note,
                PatientID = appointmentDto.PatientID,
                CreatedAt = DateTime.Now,
                StaffID = appointmentDto.StaffID,
                AppointmentDate = appointmentDto.AppointmentDate,
                CreatedBy = null
            };
            _context.Appointments.Add(createAppointment);
            await _context.SaveChangesAsync();
            return createAppointment;
        }

        public async Task<Appointment?> UpdateAppointment(int id, AppointmentDto appointmentDto)
        {
            var existingAppointment = await _context.Appointments.FindAsync(id);
            if (existingAppointment == null) return null;

            existingAppointment.Status = appointmentDto.Status;
            existingAppointment.Note = appointmentDto.Note;
            existingAppointment.PatientID = appointmentDto.PatientID;
            existingAppointment.UpdatedAt = DateTime.Now;
            existingAppointment.StaffID = appointmentDto.StaffID;
            existingAppointment.AppointmentDate = appointmentDto.AppointmentDate;
            existingAppointment.UpdatedBy = null;

            await _context.SaveChangesAsync();
            return existingAppointment;
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
