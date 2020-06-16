using AutoMapper;
using PestSchedule.Application.Common.Mappings;

namespace PestSchedule.Application.Attendance.Queries.GetAttendanceByCustomerId
{
    public class AttendanceDto : IMapFrom<Domain.Entities.Attendance>
    {
        public string VeterinaryName { get; set; }
        public string AnimalName { get; set; }

        public string AttendanceDate { get; set; }

        public string Diagnostic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Attendance, AttendanceDto>()
                .ForMember(d => d.AnimalName, opt => opt.MapFrom(s => s.Aninmal.Name))
                .ForMember(d => d.VeterinaryName, opt => opt.MapFrom(s => s.Veterinary.Name))
                .ForMember(d => d.AttendanceDate, opt => opt.MapFrom(s => s.AttendanceDate.ToString("dd/MM/yyyy")))
                .ForMember(d => d.Diagnostic, opt => opt.MapFrom( s => s.Diagnostic));
        }
    }
}
