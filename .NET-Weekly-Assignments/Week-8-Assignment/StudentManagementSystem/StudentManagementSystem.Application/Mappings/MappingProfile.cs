using AutoMapper;
using StudentManagementSystem.Application.DTOS;
using StudentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // StudyMaterial
            CreateMap<StudyMaterialEntity, StudyMaterialDto>().ReverseMap();

            // Feedback
            CreateMap<FeedbackEntity, FeedbackDto>().ReverseMap();

            // User (Admin View)
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.Role,
                           opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
