using AutoMapper;
using Kata.Application.Order.Model;
using System.Globalization;

namespace Kata.Application.Order.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderApi, Domain.Entities.Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => int.Parse(src.Id)))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => ToDateOnly(src.Date)))
                .ForMember(dest => dest.ShipDate, opt => opt.MapFrom(src => ToDateOnly(src.ShipDate)));

            CreateMap<Domain.Entities.Order, OrderDto>();

            CreateMap<IEnumerable<Domain.Entities.Order>, OrderSummaryDto>()
                .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => GetCategoryDtos(src.Select(o => o.Region))))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => GetCategoryDtos(src.Select(o => o.Country))))
                .ForMember(dest => dest.ItemTypes, opt => opt.MapFrom(src => GetCategoryDtos(src.Select(o => o.ItemType))))
                .ForMember(dest => dest.SalesChannels, opt => opt.MapFrom(src => GetCategoryDtos(src.Select(o => o.SalesChannel))))
                .ForMember(dest => dest.OrderPriorities, opt => opt.MapFrom(src => GetCategoryDtos(src.Select(o => o.Priority.ToString()))));
        }

        private DateOnly ToDateOnly(string dateString)
        {
            if (!DateTime.TryParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new Exception($"Invalid date format: {dateString}.");
            }

            return new DateOnly(parsedDate.Year, parsedDate.Month, parsedDate.Day);
        }

        private List<CategoryDto> GetCategoryDtos(IEnumerable<string> values)
        {
            return values
                .GroupBy(v => v)
                .Select(g => new CategoryDto
                {
                    Name = g.Key,
                    Total = g.Count()
                })
                .ToList();
        }
    }
}
