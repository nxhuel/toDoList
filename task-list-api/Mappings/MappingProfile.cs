using AutoMapper;
using task_list_api.Dtos;
using task_list_api.Models;

namespace task_list_api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // dto -> model
            CreateMap<TaskReqDto, TaskModel>();
            // model -> dto
            CreateMap<TaskModel, TaskDto>();
        }
    }
}
